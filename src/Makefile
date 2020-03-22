BUILD_OUTPUT = build
PUBLISH_OUTPUT = publish
PACK_OUTPUT = project.zip
DOCS_OUTPUT = doc
INSTALL_OUTPUT = install
REPO_DIR = repo

PUBLISH_SELF_CONTAINED_OUTPUT = ${PUBLISH_OUTPUT}/selfContained
PUBLISH_SELF_CONTAINED_SP_OUTPUT = ${PUBLISH_OUTPUT}/selfContainedPackages
PUBLISH_RUNTIME_DEP_OUTPUT = ${PUBLISH_OUTPUT}/runtimeDependent

APP_DIR = App
PROFILING_DIR = Profiling

BUILD_FLAGS = -c Release --nologo
RUNTIME_DEP_FLAGS = --nologo -v m
SELF_CONTAINED_FLAGS_WINDOWS = --runtime win-x64 --self-contained true --nologo -v m
SELF_CONTAINED_FLAGS_LINUX = --runtime linux-x64 --self-contained true --nologo -v m

SELF_CONTAINED_SP_FLAGS_WINDOWS = ${SELF_CONTAINED_FLAGS_WINDOWS} /p:PublishSingleFile=true
SELF_CONTAINED_SP_FLAGS_LINUX = ${SELF_CONTAINED_FLAGS_LINUX} /p:PublishSingleFile=true

all: clean profile app doc

test: SunnyCalc.Maths.Tests/SunnyCalc.Maths.Tests.csproj
	dotnet test --nologo $<

run: SunnyCalc.App/SunnyCalc.App.csproj
	dotnet run -c Release -p $<

pack: doc installer	
	git clone ../ ${REPO_DIR}
	rm -f ${PACK_OUTPUT}
	zip -r ${PACK_OUTPUT} ${REPO_DIR}/ ${DOCS_OUTPUT}/ ${INSTALL_OUTPUT}/
	rm -rf ${REPO_DIR}/ ${DOCS_OUTPUT} ${INSTALL_OUTPUT} ${BUILD_OUTPUT} ${PUBLISH_OUTPUT}

doc:
	echo "TODO: Generate docs"
	mkdir -p doc
	touch doc/docs_will_be_here

installer: app
	echo "TODO: Installers"
	mkdir -p install
	cp ${PUBLISH_SELF_CONTAINED_SP_OUTPUT}/${PROFILING_DIR}/linux/* install/
	
clean: clean_pack clean_publish clean_src
	
clean_src:
	rm -rf */bin/
	rm -rf */obj/
    
clean_publish:
	rm -rf ${BUILD_OUTPUT} ${PUBLISH_OUTPUT}
	
clean_pack:
	rm -rf ${REPO_DIR} ${DOCS_OUTPUT} ${INSTALL_OUTPUT} ${PACK_OUTPUT}

profile: SunnyCalc.Profiling/SunnyCalc.Profiling.csproj
	dotnet build ${BUILD_FLAGS} -o ${BUILD_OUTPUT}/${PROFILING_DIR}/ $<
	dotnet publish ${RUNTIME_DEP_FLAGS} -o ${PUBLISH_RUNTIME_DEP_OUTPUT}/${PROFILING_DIR} $<
	dotnet publish ${SELF_CONTAINED_FLAGS_WINDOWS} -o ${PUBLISH_SELF_CONTAINED_OUTPUT}/${PROFILING_DIR}/windows $<
	dotnet publish ${SELF_CONTAINED_FLAGS_LINUX} -o ${PUBLISH_SELF_CONTAINED_OUTPUT}/${PROFILING_DIR}/linux $<
	dotnet publish ${SELF_CONTAINED_SP_FLAGS_WINDOWS} -o ${PUBLISH_SELF_CONTAINED_SP_OUTPUT}/${PROFILING_DIR}/windows $<
	dotnet publish ${SELF_CONTAINED_SP_FLAGS_LINUX} -o ${PUBLISH_SELF_CONTAINED_SP_OUTPUT}/${PROFILING_DIR}/linux $<

app: SunnyCalc.App/SunnyCalc.App.csproj
	dotnet build ${BUILD_FLAGS} -o ${BUILD_OUTPUT}/${APP_DIR} $<
	dotnet publish ${RUNTIME_DEP_FLAGS} -o ${PUBLISH_RUNTIME_DEP_OUTPUT}/${APP_DIR} $<
	dotnet publish ${SELF_CONTAINED_FLAGS_WINDOWS} -o ${PUBLISH_SELF_CONTAINED_OUTPUT}/${APP_DIR}/windows $<
	dotnet publish ${SELF_CONTAINED_FLAGS_LINUX} -o ${PUBLISH_SELF_CONTAINED_OUTPUT}/${APP_DIR}/linux $<
	dotnet publish ${SELF_CONTAINED_SP_FLAGS_WINDOWS} -o ${PUBLISH_SELF_CONTAINED_SP_OUTPUT}/${APP_DIR}/windows $<
	dotnet publish ${SELF_CONTAINED_SP_FLAGS_LINUX} -o ${PUBLISH_SELF_CONTAINED_SP_OUTPUT}/${APP_DIR}/linux $<

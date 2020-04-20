BUILD_OUTPUT = build
PUBLISH_OUTPUT = publish
PACK_OUTPUT = project.zip
DOCS_OUTPUT = doc
INSTALL_OUTPUT = install
REPO_DIR = repo

PUBLISH_RUNTIME_DEP_EXE_OUTPUT = ${PUBLISH_OUTPUT}/runtimeDependent/executable
PUBLISH_RUNTIME_DEP_OUTPUT = ${PUBLISH_OUTPUT}/runtimeDependent/binary
PUBLISH_SELF_CONTAINED_SP_OUTPUT = ${PUBLISH_OUTPUT}/selfContainedPackages

APP_DIR = App
PROFILING_DIR = Profiling

BUILD_FLAGS = -c Release --nologo
# Runtime-dependent binaries (have to be invoked using dotnet run)
RUNTIME_DEP_FLAGS = --nologo -v m
# Runtime-dependent single-file executables (need the runtime installed but can be executed on their own)
RUNTIME_DEP_EXE_FLAGS_WINDOWS = --runtime win-x64 --self-contained false --nologo -v m /p:PublishSingleFile=true
RUNTIME_DEP_EXE_FLAGS_LINUX = --runtime linux-x64 --self-contained false --nologo -v m /p:PublishSingleFile=true
# Self-contained single-file executables (contain the runtime packed in them)
SELF_CONTAINED_SP_FLAGS_WINDOWS = --runtime win-x64 --self-contained true --nologo -v m /p:PublishSingleFile=true /p:PublishTrimmed=true
SELF_CONTAINED_SP_FLAGS_LINUX = --runtime linux-x64 --self-contained true --nologo -v m /p:PublishSingleFile=true /p:PublishTrimmed=true

.PHONY: all test run pack doc installer clean clean_src clean_doc clean_pack clean_publish profile app

all: profile app doc

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
	mkdir -p ${DOCS_OUTPUT}
	doxygen Doxyfile_app
	doxygen Doxyfile_lmath

installer: app
	echo "TODO: Installers"
	mkdir -p ${INSTALL_OUTPUT}
	cp ${PUBLISH_SELF_CONTAINED_SP_OUTPUT}/linux/${PROFILING_DIR}/* ${INSTALL_OUTPUT}/
	
clean: clean_pack clean_publish clean_src clean_doc
	
clean_src:
	rm -rf */bin/
	rm -rf */obj/
    
clean_publish:
	rm -rf ${BUILD_OUTPUT} ${PUBLISH_OUTPUT}
	
clean_pack:
	rm -rf ${REPO_DIR} ${INSTALL_OUTPUT} ${PACK_OUTPUT}

clean_doc:
	rm -rf ${DOCS_OUTPUT}

profile: SunnyCalc.Profiling/SunnyCalc.Profiling.csproj
	dotnet build ${BUILD_FLAGS} -o ${BUILD_OUTPUT}/${PROFILING_DIR}/ $<
	dotnet publish ${RUNTIME_DEP_FLAGS} -o ${PUBLISH_RUNTIME_DEP_OUTPUT}/${PROFILING_DIR} $<
	dotnet publish ${RUNTIME_DEP_EXE_FLAGS_WINDOWS} -o ${PUBLISH_RUNTIME_DEP_EXE_OUTPUT}/windows/${PROFILING_DIR}/ $<
	dotnet publish ${RUNTIME_DEP_EXE_FLAGS_LINUX} -o ${PUBLISH_RUNTIME_DEP_EXE_OUTPUT}/linux/${PROFILING_DIR}/ $<
	dotnet publish ${SELF_CONTAINED_SP_FLAGS_WINDOWS} -o ${PUBLISH_SELF_CONTAINED_SP_OUTPUT}/windows/${PROFILING_DIR}/ $<
	dotnet publish ${SELF_CONTAINED_SP_FLAGS_LINUX} -o ${PUBLISH_SELF_CONTAINED_SP_OUTPUT}/linux/${PROFILING_DIR}/ $<

app: SunnyCalc.App/SunnyCalc.App.csproj
	dotnet build ${BUILD_FLAGS} -o ${BUILD_OUTPUT}/${APP_DIR} $<
	dotnet publish ${RUNTIME_DEP_FLAGS} -o ${PUBLISH_RUNTIME_DEP_OUTPUT}/${APP_DIR} $<
	dotnet publish ${RUNTIME_DEP_EXE_FLAGS_WINDOWS} -o ${PUBLISH_RUNTIME_DEP_EXE_OUTPUT}/windows/${APP_DIR}/ $<
	dotnet publish ${RUNTIME_DEP_EXE_FLAGS_LINUX} -o ${PUBLISH_RUNTIME_DEP_EXE_OUTPUT}/linux/${APP_DIR}/ $<
	dotnet publish ${SELF_CONTAINED_SP_FLAGS_WINDOWS} -o ${PUBLISH_SELF_CONTAINED_SP_OUTPUT}/windows/${APP_DIR}/ $<
	dotnet publish ${SELF_CONTAINED_SP_FLAGS_LINUX} -o ${PUBLISH_SELF_CONTAINED_SP_OUTPUT}/linux/${APP_DIR}/ $<

TARGETS = clean 

all: clean profile build-sln run

pack:

clean:

test:

doc:

run:
	
profile:

build-sln: src/SunnyCalc.sln
	dotnet build -c Release src/SunnyCalc.sln

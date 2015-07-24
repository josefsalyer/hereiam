#! /usr/bin/env bash

XBUILD=`which xbuild`
NUNIT=`which nunit-console`
NUGET=`which nuget`
TESTED=0

$NUGET restore HereIAm/HereIAm.sln

fswatch -o . -e "*.cs" | (while read ; do
	if [ $TESTED -eq 0 ]
		then
		echo "evaluation good"
		xbuild ./HereIAm/HereIAm.sln && 
		nunit-console ./HereIAm/HereIAm.Test/bin/Debug/HereIAm.Test.dll
		TESTED=1
		sleep 5
	else
		TESTED=0
	fi
done)






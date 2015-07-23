#! /usr/bin/env bash
# this is for Java 1.8

echo 'installing java'

URL="http://javadl.sun.com/webapps/download/AutoDL?BundleId=108140"


curl -L $URL > '/tmp/jre-8u51-macosx-x64.dmg'
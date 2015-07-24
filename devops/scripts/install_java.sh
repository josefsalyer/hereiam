#! /usr/bin/env bash
# this is for Java 1.8

TOOL='java'


#commands
CURL=`which curl`
HDIUTIL=`which hdiutil`
INSTALLER=`which installer`
RM=`which rm`
JAVA=`which java`

URL="http://javadl.sun.com/webapps/download/AutoDL?BundleId=108140"
PATH='/tmp/jre-8u51-macosx-x64.dmg'
VOLUME="/Volumes/Java 8 Update 51"
PACKAGE="${VOLUME}/Java 8 Update 51.pkg"



download_java() {
	echo 'downloading java'
	$CURL -L $URL > $PATH
	exit
}

mount_installer() {
	echo 'mounting dmg'
	$HDIUTIL attach $PATH
	exit
}

install_java() {
	echo 'installing java'
	${INSTALLER} -pkg "${PACKAGE}" -target /
	exit
}


uninstall_java() {
	echo 'uninstalling java'
	$RM -fr "/Library/Internet Plug-Ins/JavaAppletPlugin.plugin"
	$RM -fr /Library/PreferencePanes/JavaControlPanel.prefpane
	exit
}

cleanup(){
	echo 'removing temp files'
	$RM -rf $PATH
}

unmount() {
	echo 'unmounting dmg'
	$HDIUTIL detach "${VOLUME}"
	exit
}

usage() {
	echo "./scripts/install_java.sh download|mount|install|unmount|uninstall"
	exit
}


case $1 in
	'download' )
		download_java ;;
	'mount' )
		mount_installer ;;
	'install' )
		install_java ;;
	'unmount' )
		unmount ;;
	'uninstall' )
		uninstall_java ;;
	'cleanup' )
		cleanup ;;
	*) 
		usage;;
esac



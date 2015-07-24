#! /usr/bin/env bash
# this is for Java 1.8

TOOL='xamarin'


#commands
CURL=`which curl`
HDIUTIL=`which hdiutil`
INSTALLER=`which installer`
RM=`which rm`
MV=`which mv`
COPY=`which cp` 

PACKAGE=""
DISKIMAGE="XamarinStudio-5.9.2.4-0.dmg"
URL="http://download.xamarin.com/studio/Mac/XamarinStudio-5.9.2.4-0.dmg"
PATH='/tmp/'
VOLUME="/Volumes/Xamarin Studio"
APP="Xamarin Studio.app"
APPLICATIONS="/Applications/"




download() {
	echo "downloading ${TOOL}"
	$CURL -L $URL > $PATH/$DISKIMAGE
	exit
}

mount() {
	echo 'mounting dmg'
	$HDIUTIL attach $PATH/$DISKIMAGE
	exit
}

install() {
	echo "installing ${TOOL}"
	$COPY -Rf "${VOLUME}/${APP}" $APPLICATIONS
	exit
}


uninstall() {
	echo "uninstalling ${TOOL}"
	$RM -rf "${APPLICATIONS}/${APP}"
	exit
}

cleanup(){
	echo 'removing temp files'
	$RM -rf $PATH/$DISKIMAGE
	
}

unmount() {
	echo 'unmounting dmg'
	$HDIUTIL detach "${VOLUME}"
	exit
}

usage() {
	echo "./scripts/install_java.sh download|mount|install|unmount|uninstall|cleanup"
	exit
}


case $1 in
	'download' )
		download ;;
	'mount' )
		mount ;;
	'install' )
		install ;;
	'unmount' )
		unmount ;;
	'uninstall' )
		uninstall ;;
	'cleanup' )
		cleanup ;;
	*) 
		usage;;
esac



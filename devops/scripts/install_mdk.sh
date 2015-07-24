#! /usr/bin/env bash
# this is for Java 1.8

TOOL='mono mdk'


#commands
CURL=`which curl`
HDIUTIL=`which hdiutil`
INSTALLER=`which installer`
RM=`which rm`



URL="http://download.mono-project.com/archive/4.0.2/macos-10-x86/MonoFramework-MDK-4.0.2.5.macos10.xamarin.x86.pkg"
PATH='/tmp/'
VOLUME=""
PACKAGE="MonoFramework-MDK-4.0.2.5.macos10.xamarin.x86.pkg"



download() {
	echo "downloading ${TOOL}"
	$CURL -L $URL > $PATH/$PACKAGE
	exit
}

mount() {
	echo 'mounting dmg'
	$HDIUTIL attach $PATH
	exit
}

install() {
	echo "installing ${TOOL}"
	${INSTALLER} -pkg "${PATH}/${PACKAGE}" -target /
	exit
}


uninstall() {
	echo "uninstalling ${TOOL}"
	
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



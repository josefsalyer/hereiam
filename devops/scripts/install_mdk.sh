#! /usr/bin/env bash
# this is for mono mdk 4.0.2.5

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


install() {
	echo "installing ${TOOL}"
	${INSTALLER} -pkg "${PATH}/${PACKAGE}" -target /
	exit
}


uninstall() {
	echo "TBD: uninstalling ${TOOL}"
	
	exit
}

cleanup(){
	echo 'removing temp files'
	$RM -rf $PATH/$PACKAGE
}


usage() {
	echo "./scripts/install_mdk.sh download|install|uninstall|cleanup"
	exit
}


case $1 in
	'download' )
		download ;;
	'install' )
		install ;;
	'uninstall' )
		uninstall ;;
	'cleanup' )
		cleanup ;;
	*) 
		usage;;
esac



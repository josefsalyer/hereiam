# hereiam
here i am 

[![Build status](https://img.shields.io/appveyor/ci/josefsalyer/hereiam/develop.svg?style=flat-square)](https://ci.appveyor.com/project/josefsalyer/hereiam)
[![Release](https://img.shields.io/github/release/josefsalyer/hereiam.svg?style=flat-square)](https://github.com/josefsalyer/hereiam/releases/latest)
[![Issues](https://img.shields.io/github/issues/josefsalyer/hereiam.svg?style=flat-square)](https://github.com/josefsalyer/hereiam/issues)

# setup instructions

# download tools
- Apple commandline tools + XCode (includes git)
	- open the App Store
	- search for xcode
	- download and install it
	- open xcode and install command line tools
	- some directions are here: [http://railsapps.github.io/xcode-command-line-tools.html](http://railsapps.github.io/xcode-command-line-tools.html) ignore the first paragraph about Ruby

- MonoSDK [http://download.mono-project.com/archive/4.0.2/macos-10-x86/MonoFramework-MDK-4.0.2.5.macos10.xamarin.x86.pkg](http://download.mono-project.com/archive/4.0.2/macos-10-x86/MonoFramework-MDK-4.0.2.5.macos10.xamarin.x86.pkg)
- Xamarin Studio [http://download.xamarin.com/studio/Mac/XamarinStudio-5.9.2.4-0.dmg](http://download.xamarin.com/studio/Mac/XamarinStudio-5.9.2.4-0.dmg)

[Setup mono to use nancy as a web server](mono_how_to_get_started.md)

# set up environment

- create/have a github.com account [http://www.github.com](http://www.github.com)

- make sure you have git installed (see the above step about installing xcode)
- set your global git name and email:
```
$> git config --global user.name "YOUR NAME HERE"
$> git config --global user.email "YOUR EMAIL HERE"
```
## generate a private keypair, from a terminal window
```

$> ssh-keygen

Generating public/private rsa key pair.
Enter file in which to save the key (/Users/<username>/.ssh/id_rsa):
Enter passphrase (empty for no passphrase): <enter a passphrase if you dare!>
Enter same passphrase again: <ditto>
Your identification has been saved in /Users/<username>/.ssh/id_rsa.
Your public key has been saved in /Users/<username>/.ssh/id_rsa.pub.
The key fingerprint is:
f4:1c:a7:31:18:38:0d:51:04:f6:b7:6b:81:fc:gb:8b <email address>

The key's randomart image is:
+--[ RSA 2048]----+
|    =O+          |
|   .o... .       |
|     .P + + .    |
|     . + + *     |
|      o S +      |
|       . o       |
|        +        |
|       . +       |
|        E o.     |
+-----------------+
```

## add your public rsa to github
```
$> cat ~/.ssh/id_rsa.pub | pbcopy
```

- navigate to your settings on github.com [https://github.com/settings/ssh](https://github.com/settings/ssh)
- Click Add SSH Key
- paste into the textbox and save!


- clone the repo
```
$> git clone git@github.com:josefsalyer/hereiam.git
```

## set up serverspec
- have/get ruby (see the above step about installing XCode)
- configure gem to install gems to your home directory
```
$> echo gem: --user-install >> ~/.gemrc
```
- Add your local gem bin file to your path
```
$> echo export PATH="$HOME/.gem/ruby/2.0.0/bin:${PATH}" >> ~/.bash_profile
$> source ~/.bash_profile
```
- install ServerSpec
```
gem install serverspec
```
- verify that you can run serverspec
```
$> cd devops
$> rake spec
```

- install mongodb

Follow the download and installation instructions here: [https://www.mongodb.org/downloads](https://www.mongodb.org/downloads)



# access stuff

# junk drawer

## if you use sublime text
```
$> mkdir -p ~/bin/
$> ln -s "/Applications/Sublime Text.app/Contents/SharedSupport/bin/subl" ~/bin/subl
```


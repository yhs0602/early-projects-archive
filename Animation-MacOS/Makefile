APP_NAME := Animation
APP_BUNDLE := $(APP_NAME).app
CONTENTS := $(APP_BUNDLE)/Contents
RESOURCES := $(CONTENTS)/Resources
EXECUTABLE := $(CONTENTS)/MacOS/$(APP_NAME)

.PHONY: all run clean

all: $(APP_BUNDLE)

$(APP_BUNDLE): main.mm Info.plist light.bmp magnet.bmp Makefile
	rm -rf "$(APP_BUNDLE)"
	mkdir -p "$(CONTENTS)/MacOS" "$(RESOURCES)"
	cp Info.plist "$(CONTENTS)/Info.plist"
	cp light.bmp magnet.bmp "$(RESOURCES)/"
	clang++ -std=c++17 -mmacosx-version-min=12.0 -fobjc-arc -Wall -Wextra -Wno-unused-parameter \
		-framework Cocoa main.mm -o "$(EXECUTABLE)"

run: all
	open "$(APP_BUNDLE)"

clean:
	rm -rf "$(APP_BUNDLE)"

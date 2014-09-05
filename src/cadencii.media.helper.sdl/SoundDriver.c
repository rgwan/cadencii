#include "SoundDriver.h"

CADENCII_MEDIA_HELPER_API(void, SoundUnprepare)() {
}

CADENCII_MEDIA_HELPER_API(void, SoundInit)() {
	Pa_Initialize();
}

CADENCII_MEDIA_HELPER_API(void, SoundExit)() {
	Pa_Terminate();
}

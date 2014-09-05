/*
 * SoundDriver.h
 * Copyright (C) 2014 Rocaloid Develop Team
 *
 * This file is part of cadencii.media.helper.sdl.
 *
 * cadencii.media.helper.sdl is free software; you can redistribute it and/or
 * modify it under the terms of the BSD License.
 *
 * cadencii.media.helper.sdl is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 */
#include <portaudio.h>
#include <stdio.h>
#include <stdbool.h>

#ifdef __cplusplus
#   define CADENCII_MEDIA_HELPER_EXTERN_C extern "C"
#else
#   define CADENCII_MEDIA_HELPER_EXTERN_C
#endif

#define CADENCII_MEDIA_HELPER_API(__return_type, __function_name) CADENCII_MEDIA_HELPER_EXTERN_C __return_type /*cdecl*/ __attribute__((cdecl)) __function_name

CADENCII_MEDIA_HELPER_API(void, SoundInit)();
CADENCII_MEDIA_HELPER_API(int, SoundPrepare)(int sample_rate);
CADENCII_MEDIA_HELPER_API(void, SoundAppend)(double *left, double *right, int length);
CADENCII_MEDIA_HELPER_API(void, SoundExit)();
CADENCII_MEDIA_HELPER_API(double, SoundGetPosition)();
CADENCII_MEDIA_HELPER_API(bool, SoundIsBusy)(); //BOOL
CADENCII_MEDIA_HELPER_API(void, SoundWaitForExit)();
CADENCII_MEDIA_HELPER_API(void, SoundSetResolution)(int resolution);
CADENCII_MEDIA_HELPER_API(void, SoundKill)();
CADENCII_MEDIA_HELPER_API(void, SoundUnprepare)();

/*CADENCII_MEDIA_HELPER_EXTERN_C void CALLBACK SoundCallback( HWAVEOUT hwo, unsigned int uMsg, unsigned long dwInstance, unsigned long dwParam1, unsigned long dwParam2 );*/

#define NUM_BUF 3

#pragma once

#ifdef DYNAMICSOUNDASSIGNMENT_EXPORTS
#define LIB_API __delspec(dllexport)
#elif DYNAMICSOUNDASSIGNMENT_IMPORTS
#define LIB_API __delspec(dllimport)
#else
#define LIB_API
#endif

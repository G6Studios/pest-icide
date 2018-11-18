/*
	A standard logger that I have used and modified over time, taken from Sprout Engine
	usage is FILE_LOG(logLEVEL) << stuff;
	This will automagically add a newline at the end of a log entry

	To set up the output file:
	FILE* file = nullptr;
	fopen_s(&file, fileName, "w");
	if (file != nullptr)
		Output2FILE::Stream() = file;
*/

#pragma once
#ifndef __LOG_H__
#define __LOG_H__

#include <sstream>
#include <string>
#include <stdio.h>
#include <string>

// See http://www.drdobbs.com/cpp/logging-in-c/201804215?pgno=1

inline std::string NowTime();

/* Represents the utils/Logger levels that we can use*/
enum TLogLevel {
	logERROR   = 0, 
	logWARNING = 1, 
	logINFO    = 2,
	logDEBUG   = 3, 
	logDEBUG1  = 4, 
	logDEBUG2  = 5, 
	logDEBUG3  = 6, 
	logDEBUG4  = 7
};

/* Generic utils/Logger class for different logging implementations */
template <typename T>
class Log
{
    public:
        Log();
        virtual ~Log();
        std::ostringstream& Get(TLogLevel level = logINFO);
    public:
        static TLogLevel& ReportingLevel();
        static std::string ToString(TLogLevel level);
        static TLogLevel FromString(const std::string& level);
    protected:
        std::ostringstream os;
    private:
        Log(const Log&);
        Log& operator =(const Log&);
};

/* Empty log constructor for our generic utils/Logger */
template <typename T>
Log<T>::Log()
{
}

/* Gets the output stream that can be used to write to this utils/Logger */
template <typename T>
    std::ostringstream& Log<T>::Get(TLogLevel level)
{
    os << NowTime();
    os << " " << ToString(level) << ": ";
    os << std::string(level > logDEBUG ? level - logDEBUG : 0, '\t');
    return os;
}

/* Destroys the utils/Logger instance, appends a newline, then outputs */
template <typename T>
Log<T>::~Log()
{
    os << std::endl;
    T::Output(os.str());
}

/* Gets and sets the logging level for the utils/Logger. Higher logging levels will be ignored */
template <typename T>
TLogLevel& Log<T>::ReportingLevel()
{
    static TLogLevel reportingLevel = logDEBUG4;
    return reportingLevel;
}

/* Gets the human-readable string for a utils/Logger level */
template <typename T>
std::string Log<T>::ToString(TLogLevel level)
{
	static const char* const buffer[] = {"ERROR", "WARNING", "INFO", "DEBUG", "DEBUG1", "DEBUG2", "DEBUG3", "DEBUG4"};
    return buffer[level];
}

/* Parses a log level from a string */
template <typename T>
TLogLevel Log<T>::FromString(const std::string& level)
{
    if (level == "DEBUG4")
        return logDEBUG4;
    if (level == "DEBUG3")
        return logDEBUG3;
    if (level == "DEBUG2")
        return logDEBUG2;
    if (level == "DEBUG1")
        return logDEBUG1;
    if (level == "DEBUG")
        return logDEBUG;
    if (level == "INFO")
        return logINFO;
    if (level == "WARNING")
        return logWARNING;
    if (level == "ERROR")
        return logERROR;
    Log<T>().Get(logWARNING) << "Unknown logging level '" << level << "'. Using INFO level as default.";
    return logINFO;
}

/* Simple class for writing to a file */
class Output2FILE
{
    public:
        static FILE*& Stream();
        static void Output(const std::string& msg);
};

/* Gets or sets the file stream for the utils/Logger */
inline FILE*& Output2FILE::Stream()
{
    static FILE* pStream = stderr;
    return pStream;
}

/* Outputs the given message to the file */
inline void Output2FILE::Output(const std::string& msg)
{
    FILE* pStream = Stream();
    if (!pStream)
        return;
    fprintf(pStream, "%s", msg.c_str());
    fflush(pStream);
}

#if defined(WIN32) || defined(_WIN32) || defined(__WIN32__)
#   if defined (BUILDING_FILELOG_DLL)
#       define FILELOG_DECLSPEC   __declspec (dllexport)
#   elif defined (USING_FILELOG_DLL)
#       define FILELOG_DECLSPEC   __declspec (dllimport)
#   else
#       define FILELOG_DECLSPEC
#   endif // BUILDING_DBSIMPLE_DLL
#else
#   define FILELOG_DECLSPEC
#endif // _WIN32

/* Defines the FILELog for logging to a file. This is basically a utils/Logger that uses a file as an output */
class FILELOG_DECLSPEC FILELog : public Log<Output2FILE> {};
//typedef Log<Output2FILE> FILELog;

/* If we don't set a max level, use DEBUG4 as the default */
#ifndef FILELOG_MAX_LEVEL
#define FILELOG_MAX_LEVEL logDEBUG4
#endif

/*
    This is where the magic happens! Basically a multi-line function definition for the pre-processor
    First, we check to see if we actually need to log, if the level is higher than the max, ignore it
    Otherwise, check to see if we can write it. Ignore if we have no file or the level > the max
    If everything else is fine, the compiler will spit out the stream to be logged to
*/
#define FILE_LOG(level) \
    if (level > FILELOG_MAX_LEVEL) ;\
    else if (level > FILELog::ReportingLevel() || !Output2FILE::Stream()) ; \
    else FILELog().Get(level)

#if defined(WIN32) || defined(_WIN32) || defined(__WIN32__)

#include <windows.h>

inline std::string NowTime()
{
    const int MAX_LEN = 200;
    char buffer[MAX_LEN];
    if (GetTimeFormatA(LOCALE_USER_DEFAULT, 0, 0,
            "HH':'mm':'ss", buffer, MAX_LEN) == 0)
        return "Error in NowTime()";

    char result[100] = {0};
    static DWORD first = GetTickCount();
    sprintf_s(result, 100, "%s.%03ld", buffer, (long)(GetTickCount() - first) % 1000);
    return result;
}

#else

#include <sys/time.h>

inline std::string NowTime()
{
    char buffer[11];
    time_t t;
    time(&t);
    tm r = {0};
    strftime(buffer, sizeof(buffer), "%X", localtime_r(&t, &r));
    struct timeval tv;
    gettimeofday(&tv, 0);
    char result[100] = {0};
    std::sprintf(result, "%s.%03ld", buffer, (long)tv.tv_usec / 1000);
    return result;
}

#endif //WIN32

#endif //__LOG_H__

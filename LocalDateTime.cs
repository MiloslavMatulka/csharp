using System;

/// <summary>
/// Local date and time formatter, command line utility
/// </summary>
public class LocalDateTime {
    public static void Main(string[] args) {
        DateTime localDateTime = DateTime.Now;
        string localDateTimeString;
        // Default format
        if (args == null || args.Length == 0) {
            localDateTimeString = localDateTime.ToString("");
        }
        // Provide format specifier on the command line
        else if (args[0] == "-f" && args.Length == 2) {
            try {
                localDateTimeString = localDateTime.ToString(args[1]);
            } catch (FormatException fe) {
                // Incorrect format
                localDateTimeString = "Error: " + fe.Message +
                     Environment.NewLine + Environment.NewLine + Help();
            }
        }
        // Help
        else if (args[0] == "-h" && args.Length == 1) {
            localDateTimeString = Help();
        }
        // Incorrect syntax
        else {
            localDateTimeString = "Error: Incorrect syntax." +
                 Environment.NewLine + Environment.NewLine + Help();
        }
        Console.WriteLine(localDateTimeString);
    }

    /// <summary>Help</summary>
    /// <returns>A string representing help.</returns>
    public static string Help() {
        string help =
            "LocalDateTime formats local date and time." +
            Environment.NewLine + "Command line utility." +
            Environment.NewLine + Environment.NewLine +
            "Usage:" + Environment.NewLine +
            "    LocalDateTime [-h] [-f format]" + Environment.NewLine +
            Environment.NewLine +
            "Options: " + Environment.NewLine +
            "    -h         Help." + Environment.NewLine +
            "    -f format  Date/time format specification" +
            Environment.NewLine +
            "               (example: \"yyyyMMddHHmmssfffffff\")." +
            Environment.NewLine + Environment.NewLine +
            "Format specifier:" + Environment.NewLine +
            "    \"d\"                  The day of the month, from 1" +
            Environment.NewLine +
            "                         through 31." +
            Environment.NewLine +
            "    \"dd\"                 The day of the month, from 01" +
            Environment.NewLine +
            "                         through 31." +
            Environment.NewLine +
            "    \"ddd\"                The abbreviated name of the day" +
            Environment.NewLine +
            "                         of the week." +
            Environment.NewLine +
            "    \"dddd\"               The full name of the day" +
            Environment.NewLine +
            "                         of the week." +
            Environment.NewLine +
            "    \"f\"                  The tenths of a second in a date and" +
            Environment.NewLine +
            "                         time value." +
            Environment.NewLine +
            "    \"ff\"                 The hundredths of a second in a date" +
            Environment.NewLine +
            "                         and time value." +
            Environment.NewLine +
            "    \"fff\"                The milliseconds in a date and time" +
            Environment.NewLine +
            "                         value." +
            Environment.NewLine +
            "    \"ffff\"               The ten thousandths of a second" +
            Environment.NewLine +
            "                         in a date and time value." +
            Environment.NewLine +
            "    \"fffff\"              The hundred thousandths of a second" +
            Environment.NewLine +
            "                         in a date and time value." +
            Environment.NewLine +
            "    \"ffffff\"             The millionths of a second in a date" +
            Environment.NewLine +
            "                         and time value." +
            Environment.NewLine +
            "    \"fffffff\"            The ten millionths of a second" +
            Environment.NewLine +
            "                         in a date and time value." +
            Environment.NewLine +
            "    \"F\"                  If non-zero, the tenths of a second" +
            Environment.NewLine +
            "                         in a date and time value." +
            Environment.NewLine +
            "    \"FF\"                 If non-zero, the hundredths" +
            Environment.NewLine +
            "                         of a second in a date and time value." +
            Environment.NewLine +
            "    \"FFF\"                If non-zero, the milliseconds" +
            Environment.NewLine +
            "                         in a date and time value." +
            Environment.NewLine +
            "    \"FFFF\"               If non-zero, the ten thousandths" +
            Environment.NewLine +
            "                         of a second in a date and time value." +
            Environment.NewLine +
            "    \"FFFFF\"              If non-zero, the hundred thousandths" +
            Environment.NewLine +
            "                         of a second in a date and time value." +
            Environment.NewLine +
            "    \"FFFFFF\"             If non-zero, the millionths" +
            Environment.NewLine +
            "                         of a second in a date and time value." +
            Environment.NewLine +
            "    \"FFFFFFF\"            If non-zero, the ten millionths" +
            Environment.NewLine +
            "                         of a second in a date and time value." +
            Environment.NewLine +
            "    \"g\", \"gg\"            The period or era." +
            Environment.NewLine +
            "    \"h\"                  The hour, using a 12-hour clock" +
            Environment.NewLine +
            "                         from 1 to 12." +
            Environment.NewLine +
            "    \"hh\"                 The hour, using a 12-hour clock" +
            Environment.NewLine +
            "                         from 01 to 12." +
            Environment.NewLine +
            "    \"H\"                  The hour, using a 24-hour clock" +
            Environment.NewLine +
            "                         from 0 to 23." +
            Environment.NewLine +
            "    \"HH\"                 The hour, using a 24-hour clock" +
            Environment.NewLine +
            "                         from 00 to 23." +
            Environment.NewLine +
            "    \"K\"                  Time zone information." +
            Environment.NewLine +
            "    \"m\"                  The minute, from 0 through 59." +
            Environment.NewLine +
            "    \"mm\"                 The minute, from 00 through 59." +
            Environment.NewLine +
            "    \"M\"                  The month, from 1 through 12." +
            Environment.NewLine +
            "    \"MM\"                 The month, from 01 through 12." +
            Environment.NewLine +
            "    \"MMM\"                The abbreviated name of the month." +
            Environment.NewLine +
            "    \"MMMM\"               The full name of the month." +
            Environment.NewLine +
            "    \"s\"                  The second, from 0 through 59." +
            Environment.NewLine +
            "    \"ss\"                 The second, from 00 through 59." +
            Environment.NewLine +
            "    \"tt\"                 The AM/PM designator." +
            Environment.NewLine +
            "    \"y\"                  The year, from 0 to 99." +
            Environment.NewLine +
            "    \"yy\"                 The year, from 00 to 99." +
            Environment.NewLine +
            "    \"yyy\"                The year, with a minimum of three" +
            Environment.NewLine +
            "                         digits." +
            Environment.NewLine +
            "    \"yyyy\"               The year as a four-digit number." +
            Environment.NewLine +
            "    \"yyyyy\"              The year as a five-digit number." +
            Environment.NewLine +
            "    \"z\"                  Hours offset from UTC, with no " +
            Environment.NewLine +
            "                         leading zeros." +
            Environment.NewLine +
            "    \"zz\"                 Hours offset from UTC, with" +
            Environment.NewLine +
            "                         a leading zero for a single-digit" +
            Environment.NewLine +
            "                         value." +
            Environment.NewLine +
            "    \"zzz\"                Hours and minutes offset from UTC." +
            Environment.NewLine +
            "    \":\"                  The time separator." +
            Environment.NewLine +
            "    \"/\"                  The date separator." +
            Environment.NewLine +
            "    \"string\", 'string'   Literal string delimiter." +
            Environment.NewLine +
            "    %                    Defines the following character" +
            Environment.NewLine +
            "                         as a custom format specifier." +
            Environment.NewLine +
            "    \\                    The escape character." +
            Environment.NewLine +
            "    Any other character  The character is copied to the result" +
            Environment.NewLine +
            "                         string unchanged.";
        return help;
    }
}

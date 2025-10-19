/**
 * The `TimeParser` class provides methods to convert time units between:
 * `seconds`, `minutes`, `hours`, `days` and `milliseconds` and also time spans,
 * handling negative values by parsing them to their positive equivalents.
 */
export default class TimeParser {
  /**
   * Converts seconds to milliseconds.
   * @override → if the value is negative it will be parsed to its positive.
   * @param seconds The number of seconds to convert.
   * @returns The equivalent milliseconds.
   */
  static fromSecondsToMilliseconds(seconds: number): number {
    return seconds < 0 ? seconds * -1000 : seconds * 1000;
  }

  /**
   * Converts minutes to milliseconds.
   * @override → if the value is negative it will be parsed to its positive.
   * @param minutes The number of minutes to convert.
   * @returns The equivalent milliseconds.
   */
  static fromMinutesToMilliseconds(minutes: number): number {
    return minutes < 0 ? minutes * -60 * 1000 : minutes * 60 * 1000;
  }

  /**
   * Converts hours to milliseconds.
   * @override → if the value is negative it will be parsed to its positive.
   * @param hours The number of hours to convert.
   * @returns The equivalent milliseconds.
   */
  static fromHoursToMilliseconds(hours: number): number {
    return hours < 0 ? hours * -60 * 60 * 1000 : hours * 60 * 60 * 1000;
  }

  /**
   * Converts days to milliseconds.
   * @override → if the value is negative it will be parsed to its positive.
   * @param days The number of days to convert.
   * @returns The equivalent milliseconds.
   */
  static fromDaysToMilliseconds(days: number): number {
    return days < 0 ? days * -24 * 60 * 60 * 1000 : days * 24 * 60 * 60 * 1000;
  }

  /**
   * Converts milliseconds to seconds.
   * @override → if the value is negative it will be parsed to its positive.
   * @param milliseconds The number of milliseconds to convert.
   * @returns The equivalent seconds.
   */
  static fromMillisecondsToSeconds(milliseconds: number): number {
    return milliseconds < 0 ? milliseconds / -1000 : milliseconds / 1000;
  }

  /**
   * Converts milliseconds to minutes.
   * @override → if the value is negative it will be parsed to its positive.
   * @param milliseconds The number of milliseconds to convert.
   * @returns The equivalent minutes.
   */
  static fromMillisecondsToMinutes(milliseconds: number): number {
    return milliseconds < 0
      ? milliseconds / -(60 * 1000)
      : milliseconds / (60 * 1000);
  }

  /**
   * Converts milliseconds to hours.
   * @override → if the value is negative it will be parsed to its positive.
   * @param milliseconds The number of milliseconds to convert.
   * @returns The equivalent hours.
   */
  static fromMillisecondsToHours(milliseconds: number): number {
    return milliseconds < 0
      ? milliseconds / -(60 * 60 * 1000)
      : milliseconds / (60 * 60 * 1000);
  }

  /**
   * Converts milliseconds to days.
   * @override → if the value is negative it will be parsed to its positive.
   * @param milliseconds The number of milliseconds to convert.
   * @returns The equivalent days.
   */
  static fromMillisecondsToDays(milliseconds: number): number {
    return milliseconds < 0
      ? milliseconds / -(24 * 60 * 60 * 1000)
      : milliseconds / (24 * 60 * 60 * 1000);
  }

  /**
   * The `getInterval` method in TypeScript calculates the time interval between two dates in the
   * specified time unit.
   * @param {Date} fromDate - The `fromDate` parameter is a Date object representing the starting date
   * and time for the interval calculation. If no value is provided, it defaults to the current date and
   * time.
   * @param {Date} [toDate] - The `toDate` parameter in the `getInterval` method is an optional
   * parameter that specifies the end date for calculating the interval. If `toDate` is not provided,
   * the method will default to the start date plus one day.
   * @param {timeunit} [unit=milliseconds] - The `unit` parameter in the `getInterval` method specifies
   * the time unit in which you want to retrieve the time interval between the `fromDate` and `toDate`.
   * It can be one of the following values:
   * @returns The `getInterval` method returns a number representing the time interval between the
   * `fromDate` and `toDate` parameters, measured in the specified `unit` (defaulting to milliseconds if
   * not provided).
   */
  static getInterval(
    fromDate: Date = new Date(),
    toDate: Date,
    unit: timeunit = 'milliseconds',
  ): number {
    const differenceInMs = Math.max(0, toDate.getTime() - fromDate.getTime());

    switch (unit) {
      case 'milliseconds':
        return differenceInMs;
      case 'seconds':
        return TimeParser.fromMillisecondsToSeconds(differenceInMs);
      case 'minutes':
        return TimeParser.fromMillisecondsToMinutes(differenceInMs);
      case 'hours':
        return TimeParser.fromMillisecondsToHours(differenceInMs);
      case 'days':
        return TimeParser.fromMillisecondsToDays(differenceInMs);
      default:
        return differenceInMs;
    }
  }

  /**
   * This getter returns the date for tomorrow in UTC format.
   * @returns The `getTomorrowDate` static getter returns a Date object representing the date and
   * time for tomorrow at midnight in UTC time.
   */
  static get getTomorrowDate() {
    const now = new Date();

    return new Date(
      Date.UTC(
        now.getUTCFullYear(),
        now.getUTCMonth(),
        now.getUTCDate() + 1,
        0,
        0,
        0,
      ),
    );
  }
}

/**
 * The `timeunit` type specifies roman time units
 */
export type timeunit =
  | 'milliseconds'
  | 'seconds'
  | 'minutes'
  | 'hours'
  | 'days';

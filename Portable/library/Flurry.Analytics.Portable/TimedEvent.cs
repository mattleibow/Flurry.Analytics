using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flurry.Analytics.Portable
{
	/// <summary>
	/// Represents the duration of a timed event.
	/// </summary>
	public class TimedEvent : IDisposable
	{
		internal TimedEvent(string eventId)
			: this(eventId, null)
		{
		}

		internal TimedEvent(string eventId, IDictionary<string, string> parameters)
		{
			EventId = eventId;
            if (parameters != null)
            {
                Parameters = new Dictionary<String, string>(parameters);
            }
		}

		/// <summary>
		/// Gets the event identifier.
		/// </summary>
		/// <value>The event identifier.</value>
		public string EventId { get; private set; }

		/// <summary>
		/// Gets the parameters associated with the event that will be sent to the server.
		/// </summary>
		/// <value>The parameters associated with the event.</value>
		public IDictionary<string, string> Parameters { get; private set; }

		/// <summary>
		/// Ends the timed event.
		/// </summary>
		public void EndEvent()
		{
			EndEvent(Parameters);
		}

		/// <summary>
		/// Ends the timed event. 
		/// If parameters are provided, this will overwrite existing parameters with the same name or create new 
		/// parameters if the name does not exist in the parameter collection set by 
		/// <see cref="AnalyticsApi.LogTimedEvent(System.String, System.Collections.Generic.IDictionary&lt;System.String, System.String&gt;)"/>.
		/// </summary>
		/// <param name="parameters">The parameters associated with the event.</param>
		public void EndEvent(IDictionary<string, string> parameters)
		{
			AnalyticsApi.LogEvent("ËNDING EVENT" + EventId);

			if (parameters == null)
				AnalyticsApi.EndTimedEvent(EventId);
			else
				AnalyticsApi.EndTimedEvent(EventId, parameters);
		}

		/// <summary>
		/// Ends the timed event.
		/// </summary>
		void IDisposable.Dispose()
		{
			EndEvent();
		}
	}
}

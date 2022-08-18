namespace FrameworkExample.Core.Utilities.Enum
{
    public class Enums
    {
        /// <summary>
        /// Enum for Logging. The type of the action to be logged.
        /// </summary>
        public enum LogType
        {
            [System.ComponentModel.Description("NONE")]
            None = 0,
            [System.ComponentModel.Description("INSERT")]
            Insert = 1,
            [System.ComponentModel.Description("DELETE")]
            Delete = 2,
            [System.ComponentModel.Description("UPDATE")]
            Update = 3,
            [System.ComponentModel.Description("STATUS")]
            Status = 4,
            [System.ComponentModel.Description("ERROR")]
            Error = 5,
        }

        /// <summary>
        /// Enum for Data Tables. Use for Data is still in use or deleted.
        /// </summary>
        public enum Status
        {
            [System.ComponentModel.Description("ACTIVE")]
            Active = 0,
            [System.ComponentModel.Description("DELETED")]
            Deleted = 1,
            [System.ComponentModel.Description("PASIVE")]
            Pasive = 1,
        }

        /// <summary>
        /// Enum for StatusData<T>
        /// </summary>
        public enum StatusEnum
        {
            [System.ComponentModel.Description("ERROR")]
            Error = 0,
            [System.ComponentModel.Description("SUCCESSFUL")]
            Successful = 1,
            [System.ComponentModel.Description("WARNING")]
            Warning = 2,
            [System.ComponentModel.Description("NO DATA")]
            EmptyData = 3,
            [System.ComponentModel.Description("ALREADY EXISTS")]
            RecordExist = 4,
            [System.ComponentModel.Description("CONFIRM")]
            Confirm = 5,
            [System.ComponentModel.Description("INFO")]
            Info = 6,
        }
    }
}

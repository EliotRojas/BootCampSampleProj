namespace SampleProject.Business.Exceptions
{
    /// <summary>
    /// Exception used when creating/updating a Sample with an already existing name
    /// </summary>
    public class SampleNameIsUsedException : System.Exception
    {
        /// <summary>
        /// Gets exception message
        /// </summary>
        public override string Message
        {
            get
            {                
                return base.Message;
            }
        }
    }
}
namespace En_Luna.Helpers
{
    public static class PermissionHelper
    {
        /// <summary>
        /// Determines whether the current context has the CanRead permission.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   <c>true</c> if this instance can read the specified context; otherwise, <c>false</c>.
        /// </returns>
        public static bool CanRead(HttpContext context)
        {
            if (!context?.Items?.ContainsKey("CanRead") ?? true)
            {
                return false;
            }

            return bool.Parse(context.Items["CanRead"].ToString());
        }

        /// <summary>
        /// Determines whether the current context has the CanWrite permission
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   <c>true</c> if this instance can write the specified context; otherwise, <c>false</c>.
        /// </returns>
        public static bool CanWrite(HttpContext context)
        {
            if (!context?.Items?.ContainsKey("CanWrite") ?? true)
            {
                return false;
            }

            return bool.Parse(context.Items["CanWrite"].ToString());
        }
    }
}

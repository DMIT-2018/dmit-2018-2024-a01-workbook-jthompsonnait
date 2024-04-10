#nullable disable
using HogWildSystem.ViewModels;
using HogWildSystem.DAL;

namespace HogWildSystem.BLL
{
    public class WorkingVersionService
    {
        #region Fields

        /// <summary>
        /// The hog wild context
        /// </summary>
        private readonly HogWildContext _hogWildContext;

        #endregion

        // Constructor for the WorkingVersionService class.
        internal WorkingVersionService(HogWildContext hogWildContext)
        {
            // Initialize the _hogWildContext field with the provided HogWildContext instance.
            _hogWildContext = hogWildContext;
        }
        public WorkingVersionView GetWorkingVersion()
        {
            return
                _hogWildContext.WorkingVersions
                    .Select(x => new WorkingVersionView
                    {
                        VersionId = x.VersionId,
                        Major = x.Major,
                        Minor = x.Minor,
                        Build = x.Build,
                        Revision = x.Revision,
                        AsOfDate = x.AsOfDate,
                        Comments = x.Comments
                    }).FirstOrDefault();
        }
    }
}

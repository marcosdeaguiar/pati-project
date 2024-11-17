namespace Pati.Validation.Core
{
    /// <summary>
    /// Interface to transform entity before validation.
    /// </summary>
    public interface ITransformable
    {
        /// <summary>
        /// Method called to transform internal data of a request or view model.
        /// </summary>
        void Transform();
    }
}

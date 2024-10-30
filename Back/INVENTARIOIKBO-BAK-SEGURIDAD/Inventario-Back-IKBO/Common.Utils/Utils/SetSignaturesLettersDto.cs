using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Dto
{
    /// <summary>
    /// Class SetSignaturesLettersDto.
    /// </summary>
    /// <remarks>Augusto Recuero</remarks>
    [ExcludeFromCodeCoverage]
    public class SetSignaturesLettersDto
    {
        /// <summary>
        /// Gets or sets the Signature.
        /// </summary>
        /// <value>The Signature.</value>
        /// <remarks>Augusto Recuero</remarks>
        public string Signature { get; set; }
        /// <summary>
        /// Gets or sets the Position.
        /// </summary>
        /// <value>The Position.</value>
        /// <remarks>Augusto Recuero</remarks>
        public string Position { get; set; }
        /// <summary>
        /// Gets or sets the Document.
        /// </summary>
        /// <value>The Document.</value>
        /// <remarks>Augusto Recuero</remarks>
        public string Document { get; set; }
        /// <summary>
        /// Gets or sets the Expedition Location.
        /// </summary>
        /// <value>The Expedition Location.</value>
        /// <remarks>Augusto Recuero</remarks>
        public string ExpeditionLocation { get; set; }

    }
}
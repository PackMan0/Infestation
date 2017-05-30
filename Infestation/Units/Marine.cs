namespace Infestation.Units
{
    using System.Collections.Generic;
    using Enums;
    using Supplements;

    public class Marine : Human
    {
        public Marine(string id, ISupplement defaultSupplement)
            : base(id)
        {
            this.AddSupplement(defaultSupplement);
        }
    }
}

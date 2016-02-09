using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinityLights.Entities
{
    public class ProductImage
    {
        /// <summary>
        /// Image ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product image
        /// </summary>
        public string Image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinityLights.Entities
{
    public class Product
    {
        /// <summary>
        /// Product ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Product image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Product image
        /// </summary>
        public string Dimensions { get; set; }

        /// <summary>
        /// Product lights source
        /// </summary>
        public string LightSource { get; set; }
    }
}

namespace Personal.Controllers.Work
{
    public partial class WorkController : Controller
    {
        /// <summary>
        /// Square root API Service. Just to demostrate that i know how to use this.
        /// </summary>
        /// <param name="id">optional value </param>
        /// <returns>square root of given number if id is provided</returns>
        public JsonResult WebApiExample(string id)
        {
            //TODO: max number of request.
            ResultObject response;
            if (id == null)
            {
                response = new ResultObject();
                response.OK = true;
                response.Id = 9876;
                response.Name = "this is an example response, add an 16Bits integer (WebApiExample/99) to obtain the square root of a number";
            }
            else
            {
                response = SquareResult(id);
            }
            response.Attributes.Add("scoped-GUID", _scopedService.GetID().ToString());
            response.Attributes.Add("singletonGUID", _singletonService.GetID().ToString());
            foreach (var header in Request.Headers)
            {
                response.Attributes.Add("Header-" + header.Key, header.Value);
            }

            return Json(response);
        }
        /// <summary>
        /// Backend function, just for testing purposes.
        /// </summary>
        /// <param name="number">Value of number</param>
        /// <returns>square root of given number</returns>
        public ResultObject SquareResult(string number)
        {
            //TODO: translate, globalization            
            using (var response = new ResultObject())
            {
                response.Id = -1;
                response.OK = false;

                if (long.TryParse(number, out _))
                {
                    if (short.TryParse(number, out short number_))
                    {
                        var square = (int)System.Math.Sqrt(number_);
                        response.Name = $"The Square root of {number} is {square}";
                        response.Id = number_;
                        response.OK = true;
                    }
                    else
                    {
                        response.Name = $"El valor no es un numero entero de 16Bits, debe ser mayor a {short.MinValue} y menor que {short.MaxValue}";
                    }
                }
                else
                {
                    response.Name = "El valor no es un numero valido, validé con Int64.TryParse, puede que si sea un numero pero muy grande y pude provocar desbordamiento";
                }

                return response;
            }
        }
    }
}
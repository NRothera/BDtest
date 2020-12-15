namespace  BDApiTest.services.pathParams
{
    public class GetPaymentInitDetailsPathParams : PathParams
    {
        public GetPaymentInitDetailsPathParams(paymentInitPath path)
        {
            resource = path.resource;
        }
    }

    public static class paymentInitPaths
    {
        /// <summary>
        /// <para>Resource used to get initial payment details</para>
        /// <para>Method: POST</para>
        /// <para>URLSegments to be replaced: userid</para>
        /// </summary>
        public static paymentInitPath CREATE_INITIAL_PAYMENT_RECORD_BY_USERID = new paymentInitPath() { Method = "POST", resource = "/{userid}" };
    }

    public class paymentInitPath
    {
        public string Method { get; set; }
        public string resource { get; set; }
    }
}

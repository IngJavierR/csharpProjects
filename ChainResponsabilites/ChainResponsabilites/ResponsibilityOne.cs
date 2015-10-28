using System;

namespace ChainResponsabilites
{
    class ResponsibilityOne : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request == 1)
            {
                Console.WriteLine("ResponsibilityOne:" + request);
            }
            else
            {
                Successor?.HandlerRequest(request);
            }
        }
    }
}

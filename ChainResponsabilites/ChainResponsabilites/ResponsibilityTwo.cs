using System;

namespace ChainResponsabilites
{
    class ResponsibilityTwo : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request == 2)
            {
                Console.WriteLine("ResponsibilityTwo:" + request);
            }
            else
            {
                Successor?.HandlerRequest(request);
            }
        }
    }
}

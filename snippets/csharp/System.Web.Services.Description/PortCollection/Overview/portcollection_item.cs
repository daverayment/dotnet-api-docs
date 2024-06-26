﻿// System.Web.Services.Description.PortCollection
// System.Web.Services.Description.PortCollection.Remove
// System.Web.Services.Description.PortCollection.Item(String)
// System.Web.Services.Description.PortCollection.Item(Int32)
/*
  The following sample reads the contents of a file 'MathService_cs.wsdl'
  into a 'ServiceDescription' instance. It gets the collection of Service
  instances from 'ServiceDescription'. It instantiates 'PortCollection' for
  each service in the collection. It access the ports from the collection and
  displays them. It accesses a port by its name from the collection and
  displays its index. It adds a new port and calls 'Remove'
  to remove the newly added port. The programs writes a new web service
  description file.
*/

using System;
using System.Web.Services.Description;

class PortCollection_Item
{
   public static void Main()
   {
      try
      {
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
         Service myService;
         PortCollection myPortCollection;

         ServiceDescription myServiceDescription =
            ServiceDescription.Read("MathServiceItem_cs.wsdl");

         Console.WriteLine("Total number of services : "
            + myServiceDescription.Services.Count);

         for(int i=0; i < myServiceDescription.Services.Count; ++i)
         {
            myService = myServiceDescription.Services[i];
            Console.WriteLine("Name : " + myService.Name);

            myPortCollection = myService.Ports;

            // Create an array of ports.
            Console.WriteLine("\nPort collection :");
            for(int i1=0 ; i1 < myService.Ports.Count ; ++i1)
            {
               Console.WriteLine("Port[" + i1+"] : " +
                  myPortCollection[i1].Name);
            }
// </Snippet4>

            string strPort = myPortCollection[0].Name;
            Port myPort = myPortCollection[strPort];
            Console.WriteLine("\nIndex of Port[" + strPort + "] : " +
               myPortCollection.IndexOf(myPort));

// </Snippet3>

            Port myPortTestRemove = myPortCollection[0];

            Console.WriteLine("\nTotal number of ports before removing "
               + "a port '" + myPortTestRemove.Name +"' is : "
               + myService.Ports.Count);

            myPortCollection.Remove(myPortTestRemove);

            Console.WriteLine("Total number of ports after removing "
               + "a port '" + myPortTestRemove.Name +"' is : "
               + myService.Ports.Count);

            // Create the WSDL file.
            myPortCollection.Insert(0, myPortTestRemove);
            myServiceDescription.Write("MathServiceItemNew_cs.wsdl");
// </Snippet2>
// </Snippet1>
         }
      }
      catch(Exception ex)
      {
         Console.WriteLine("Exception: " + ex.Message);
      }
   }
}

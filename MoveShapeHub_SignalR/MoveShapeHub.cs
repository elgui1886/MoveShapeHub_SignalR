using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using MoveShapeHub_SignalR.Model;

namespace MoveShapeHub_SignalR
{
    public class MoveShapeHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void UpdateShape(ShapeModel shapeModel)
        {
            shapeModel.LastUpdatedBy = Context.ConnectionId;

            //Invio le modifiche a tutti tranne all ultimo che ha effettuato la modifica
            Clients.AllExcept(shapeModel.LastUpdatedBy).sendUpdatedShape(shapeModel);
        }
    }
}
void Square::handleMessage(int inMessage)
{
    switch (inMessage) {
        case kMessageMouseDown:
            handleMouseDown();
            break;
        case kMessageInvert:
            handleInvert();
            break;
        default:
            // Message not recognized--chain to superclass
            Shape::handleMessage(inMessage);
    }
}

void Shape::handleMessage(int inMessage)
{
    switch (inMessage) {
        case kMessageDelete:
            handleDelete();
            break;
        default:
        {
            stringstream ss;
            ss << __func__ << ": Unrecognized message received: " << inMessage;
            throw invalid_argument(ss.str());
        }
    }
}

MouseLocation loc = getClickLocation();
Shape* clickedShape = findShapeAtLocation(loc);
if (clickedShape)
    clickedShape->handleMessage(kMessageMouseDown); 

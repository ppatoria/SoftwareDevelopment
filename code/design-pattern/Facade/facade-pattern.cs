/*
 * ************************************************************************
 *                             Facade Pattern                             *
 **************************************************************************
 * Cretes wrapper over the internal subsystem / modules .
 * 1. Hide legacycode:
 * -------------------
 * Often you have to deal with old,decayed, legacy systems that are brittle to
 * work with and no longer offer a coherent object model. In these cases, it can be easier to create
 * a new set of well-designed APIs that sit on top of the old code. Then all new code can use these
 * new APIs.Once all existing clients have been updated to the new APIs, the legacy code can be
 * completely hidden behind the new facade (making it an encapsulating facade).

 * 2.Create convenience APIs:
 * ------------------------
 * There is often a tension between providing general, flexible routines that provide more power versus simple easy-to-use routines
 * that make the common use cases easy. A facade is a way to address this tension by allowing both
 * to coexist. In essence, a convenience API is a facade. I used the example earlier of the OpenGL
 * library, which provides low-level base routines, and the GLU library, which provides higher-level
 * and easier-to-use routines built on top of the GL library.
 *
 * 3.Support reduced-or alternate-functionality APIs:
 * --------------------------------------------------
 * By abstracting away the access to the underlying subsystems, it becomes possible to replace certain subsystems without affecting your
 * client’s code. This could be used to swap in stub subsystems to support demonstration or test
 * versions of your API. It could also allow swapping in different functionality, such as using a dif-
 * ferent 3D rendering engine for a game or using a different image reading library. As a real-world
 * example, the Second Life viewer can be built against the proprietary KDUJPEG-2000 decoder
 * library. However, the open source version of the viewer is built against the slower Open JPEG library.
*/


interface IAgoraConnection
{
    void Open ();
    void Close ();    
}

class AgoraConnection : IAgoraConnection
{
    TssClient tssClient = null;
    TisClient tisClient = null;
    TnsClient tnsClient = null;

    void Open ()
        {
            tssClient = new TssClient();
            tssClient.Open();
            if(tssClient.IsOpen)
            {
                tisClient.Open();
                tnsClient.Open();
            }                
        }

    void Close ()
        {
            tnsClient.Close();
            tisClient.Close();
            tssClient.Close();
        }
}

class TssClient
{
    public void Open()
        {
            // ...            
        }
    public void Close()
        {
            // ....
        }
    public IsOpen
        {
            get
            {
                // ........
                return true
            }
        }    
}

class TisClient
{
    public void Open()
        {
            // ...            
        }
    public void Close()
        {
            // ....
        }
}

class TnsClient
{
    public void Open()
        {
            // ...            
        }
    public void Close()
        {
            // ....
        }
}

class Client
{
    public static void Main()
        {
            try
            {
                IAgoraConnection ageConnection = new AgoraConnection();
                agrConnection.Open();    
                // ...
            }
            finally
            {
                agrConnection.Close();
            }            
        }
}
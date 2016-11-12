using System;

/**
 * Front End ---> Intermediate Layer ---> Application
 *
 * There are three application layers that can deal with a help request in this example — 
 * (1) the front end, 
 * (2) the intermediate layer, 
 * (3) and the application object 
 * — and you want to chain those objects together 
 * To chain them, you can pass to each object’s constructor the next object in the chain — its successor in the chain — as shown below
 **/


public class TestHelp
{
    public static void Main()
    {
        const int FRONT_END_HELP          = 1;
        const int INTERMEDIATE_LAYER_HELP = 2;
        const int GENERAL_HELP            = 3;

        Application app                     = new Application();
        IntermediateLayer intermediateLayer = new IntermediateLayer(app);
        FrontEnd frontEnd                   = new FrontEnd(intermediateLayer);

        frontEnd.getHelp(GENERAL_HELP);
    }
}

public interface HelpInterface
{
    void getHelp(int helpConstant);
}

public class FrontEnd : HelpInterface
{
    const int FRONT_END_HELP = 1;
    HelpInterface successor;

    public FrontEnd(HelpInterface s){
        successor = s;
    }

    public void getHelp(int helpConstant){
        if(helpConstant != FRONT_END_HELP){
            successor.getHelp(helpConstant);
        } else {
            Console.WriteLine("This is the front end. Don't you like it?");
        }
    }
}


public class IntermediateLayer : HelpInterface
{
    const int INTERMEDIATE_LAYER_HELP = 2;
    HelpInterface successor;

    public IntermediateLayer(HelpInterface s){
        successor = s;
    }

    public void getHelp(int helpConstant){
        if(helpConstant != INTERMEDIATE_LAYER_HELP){
            successor.getHelp(helpConstant);
        } else {
            Console.WriteLine("This is the intermediate layer. Nice, eh?");
        }
    }
}


public class Application : HelpInterface
{

    public Application(){
    }

    public void getHelp(int helpConstant){
        Console.WriteLine("This is the MegaGigaCo application.");
    }
}



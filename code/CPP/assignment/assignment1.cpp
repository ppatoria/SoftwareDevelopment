#include<iostream>
#include<string>
using namespace std;
class CuboidMetal
{
private:
    char  *metalType;
    float length;
    float breadth;
    float height;
    float hypotenuse;
    float mass;
    bool bSuccess;
    float accurate_density;
    
    float getVolume(){
        float v=length*breadth*height;
        return v;
    }
      
    float getDensity(){
        float d=mass/getVolume();
        return d;
    }
public:
    CuboidMetal (char*n,
                 float l,
                 float b,
                 float h, 
                 float hy, 
                 float m,
                 float a){

        bSuccess=false;

        if(l > 0 && 
           b > 0 && 
           h > 0 && 
           hy > 0 && 
           ((l * l + b * b + h * h) == (hy * hy)))
        {
            metalType=new char[strlen(n)+1];
            strcpy(metalType,n);
            length=l;
            breadth=b;
            height=h;
            hypotenuse=hy;
            mass=m;
            accurate_density=a;
            bSuccess=true;// object successfully created.
        }
        else
            cout <<"Object cannot be created with these attributes. " 
                 <<"Please verify."<<endl;
    }

    bool getSuccess(){
        return bSuccess;
    }
      
    CuboidMetal& operator=(CuboidMetal & obj){
        cout<<"Assignment operator Called"<<endl;
        if(this==&obj)        
            return *this;        
        else{
            if(obj.metalType){
                delete metalType;
                metalType=new char[strlen(obj.metalType)+1];
                strcpy(metalType,obj.metalType);
            }else{
                metalType=new char[1];
                metalType[0]='\0';
            }
            length=obj.length;
            breadth=obj.breadth;
            height=obj.height;
            mass=obj.mass;
            accurate_density=obj. accurate_density;
        }
        return *this;
    }

    void DeterminePurity(){
        float d=getDensity();
        cout<<"Metal type is "<<metalType<<endl;
        cout<<"Volume is "<<getVolume()<<endl;
        cout<<"Density is "<<d<<endl;
        if(d==accurate_density)
            cout<<"Metal "<<metalType<<" is pure."<<endl;
        else
            cout<<"Metal "<<metalType<<" is not pure."<<endl;
    }
};
int main()
{
    CuboidMetal   c1("Silver",3,4,12,13,1512,10.5);
    CuboidMetal   c2("Gold",2,3,6,7,7103,19.3);
    c2=c1;
    c2.DeterminePurity();
}

class Image;
extern Image* LoadAnImageFile(const char*);

class ImagePtr
{
public:
    ImagePtr(const char* imageFile);
    virtual ~ImagePtr();
    virtual Image* operator->();
    virtual Image& operator*();
private:
    Image* LoadImage();
private:
    Image* _image
    const char* _imageFile
};

ImagePtr::ImagePtr(const char* theImageFile)
{
    _imageFile = theImageFile;
    _image = 0;
}

Image* ImagePtr::LoadImage()
{
    if(_image = = 0)
        _image = LoadAnImageFile(_imageFile);
    return(_image);
}

/*overloaded -> and * use LoadImage to return _image to callers and loading it if necessary */
Image* ImagePtr:: operator->()
{
    return LoadImage();
}

Image& ImagePtr:: operator*()
{
    return *LoadImage();
}

int main()
{
    /*
     * now using this code, we can use Image operations through ImagePtr objects without making the operations part of the ImagePtr interface.
     */

    //constructor first, set up a pointer to image, a proxy
    ImagePtr image = ImagePtr(“theImageFileName”);
    
    //image is of Image class
    image->Draw(Point(50, 100)); //through the proxy
    
    /* 
     *here the overloaded operator -> is used to return the 
     * address of the real object and invoke the LoadImage() function which in turn calls the LoadAnImageFile() function as illustrated thus ….. 
     */
    //(image.operator->( ))->Draw(Point(50, 100));
}

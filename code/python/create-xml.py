import xml.etree.cElementTree as ET

download_path = "download_path"
install_path  = "install_path"

root = ET.Element("native")
doc  = ET.SubElement(root, "nativeConfiguration")

ET.SubElement(doc, "download", name="blah").text    = download_path
ET.SubElement(doc, "install",  name="asdfasd").text = install_path

dependencies = ET.SubElement(doc, "dependencies")
ET.SubElement(dependencies, "groupid").text = "1234"

tree = ET.ElementTree(root)
tree.write("filename.xml")

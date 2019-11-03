import re, requests, wget
from bs4 import BeautifulSoup

# Scrape real estate websites to fetch square footage, picture(s), price
def getListings():
    data = requests.get("https://sothebysrealty.ca/en/search-results/region-montreal-quebec-real-estate/price-0-10000000/status-1/view-grid/show-mls/sort-1/pp-32/")
    soup = BeautifulSoup(data.text, "html.parser")

    #images = getImages(soup)

 #   for image in images:
 #       2+2
 #       print(image['src'])
  
def getImages(soup):    
    images = []
    for div in soup.find_all('div', { 'class': 'mprop grid-prop view-grid smallshad res-prop' }):   
        print(div)
        return
        
    #return images
        


class Listing:
    def __init__(self, image, price, sqFt):
        self.image = image
        self.price = price
        self.sqFt = sqFt

getListings()
# finn-mining-scheduler-azure

This timer function is written in c#. This project is associated with another finn mining project that scans finn.no for 
new realstate ads and then stores then in json. Then it scans the stored linsk for price variations.

The details of the project is in another repo (https://github.com/Soumya117/finnazureflaskapp).
The timer runs every 6 hour and requests scan for the website. It logs the response in case of success or failure.

This app calls following urls to request a new scan:
1. https://finn-mining.azurewebsites.net/links?scan=yes to scan finn.no.
2. https://finn-mining.azurewebsites.net/price?scan=yes to scan the links for price.

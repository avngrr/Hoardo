# Hoardo
## About
Cause i started experimenting with Kubernetes i tried installing sonarr and radarr. I ran into multiple troubles trying to share the configuration of the multiple pods. Not really wanted to work with Kubernetes to only run like 1 pod. Then i tried solving them and came accross 1 major problem. Its using SQLite and that does not really work well with multiple pods. 
Then i just decided to make my own PVR. It will be a good lesson for myself programming for multiple pods. Want to make this as flexile as possible by integrating multiple databases like Postgres, MSSQL, ....
## Starting features
- Want to run this as container/pod in Kubernetes: api should be reachable, and frontend blazor
- Adding current movie/tvshow list from files: volume in container
- Adding indexers: Currently only torrent indexers
- Adding movie/tvshow.
- Adding download client. Currently only transmission
- Search in the indexer for download and manuallly choose wich should be used and then automatically sending it to the download client
- Copy the downloaded files to the movie/tvshow volume in correct folder: Moviename folder, tvshowname folder\Season number
- This all should be stored in backend db: currently only MSSQL
## Extra features (suspect to change)
- Extra database backends: Postgres, MySQL, ...
- Automatic search for a download
- Custom folder structure for movies/tvshows
- More indexers + NZB
- More download clients: Deluge, Qbitorrent, ... 

## More information
So to make sure i test this out in Kubenetes i am going to setup a CI/CD pipeline with Jenkins. This is to ensure easy transition from my development to the Kubernetes testing. 
So the moment i commit to master Jenkins will pick this up, run some tests and then install it to the test Kubernetes environment i setup at home.

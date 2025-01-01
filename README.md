# What is this?
In simplest terms, this is a single page CRUD app that allows fast updating of the db used to store the chat history for Dabi.

This chat history is used to fine tune Dabi, the AI pet, to improve his personality. Having a single page to perform all actions makes it easier and faster to manually perform the human components of the RLHF loop (Reinforcement Learning from Human Feedback)

There is a page for viewing the entire DB, as well as a page for "Hello World" as an example of how an API would work.

# Install Requirements

dotnet 8+

docker

AWS CDK (later)

## Docker commands to remember and make use of:

build:
`docker build --no-cache -t dabisbraincellfixer .`

run
`docker run -d -p 5000:5000 --name dabisbraincellfixer-container -v ./dabibraincell.db:/app/dabibraincell.db dabisbraincellfixer`

stop and remove all containers
`docker stop $(docker ps -q) && docker rm $(docker ps -a -q)`

prune all unused images, all unused volumes
`docker system prune -a --volumes`

Build must be run from the same directory as the Dockerfile. If it is desired to run it from another directory, the following needs to be added:

`-f /path/to/file`

Worth noting: The SQLite db currently being used may not make it to the final version of the application if/when it is pushed to the cloud. This is purely to understand better how docker works, and because the main body of Dabi uses SQLite.

# AWS CDK deployment

In progress.
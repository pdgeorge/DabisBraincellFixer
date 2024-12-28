# What is this?
In simplest terms, this is a single page CRUD app that allows fast updating of the db used to store the chat history for Dabi.

This chat history is used to fine tune Dabi, the AI pet, to improve his personality. Having a single page to perform all actions makes it easier and faster to manually perform the human components of the RLHF loop (Reinforcement Learning from Human Feedback)

# Istall Requirements

dotnet 8+
docker
AWS CDK (later)

## Docker commands to remember and make use of:

docker build --no-cache -t dabisbraincellfixer .

docker run -d -p 5000:5000 --name dabisbraincellfixer-container -v ./dabibraincell.db:/app/dabibraincell.db dabisbraincellfixer

Worth noting: The SQLite db currently being used may not make it to the final version of the application if/when it is pushed to the cloud. This is purely to understand better how docker works, and because the main body of Dabi uses SQLite.

# AWS CDK deployment

In progress.
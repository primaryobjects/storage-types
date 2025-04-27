Storage Demo
=============

StorageDemo is a Blazor Server application that demonstrates different types of data storage, including structured, semi-structured, and unstructured data. It uses SQLite for structured data and JSON for unstructured data.

## Features
- Displays structured data from an SQLite database.
- Renders unstructured data (images) from a JSON file.
- Built with Blazor Server and Dockerized for easy deployment.

## Quick Start

1. Download [Docker](https://www.docker.com/products/docker-desktop).
2. Run the container `docker-compose up -d`.

*This will pull the container image from the GitHub Docker Registry.*

## Run the Application with Docker

To manually start the application using Docker, follow these steps:

1. Build the Docker image:
    ```bash
    docker build -t storage-demo .
    ```
2. Run the Docker container:
    ```bash
    docker run -d -p 8080:80 --name storage-demo storage-demo
    ```

3. Access the application in your browser at http://localhost:8080

## Build and Publish the Docker Image

After making changes to the project, the Docker container can be built and published to the Github Container Registry using the following steps.

```bash
docker login --username <USERNAME> --password <YOUR_PERSONAL_ACCESS_TOKEN> ghcr.io
docker build -t ghcr.io/primaryobjects/storage-demo:latest .
docker push ghcr.io/primaryobjects/storage-demo:latest
```

### Running the Docker Image

The Docker image can be launched using the following command to read `docker-compose.yml`.

```bash
docker-compose up -d
```

Alternatively, manually launch the container.

```bash
docker run --name storage-demo-container -d -p 8080:80 ghcr.io/primaryobjects/storage-demo:latest
```

## Project Structure

```text
StorageDemo/
├── Components/
│   ├── Data/                # Contains database.json and database.sqlite
│   ├── Layout/              # Contains layout components like NavMenu
│   ├── Pages/               # Contains Blazor pages like Home, Structured_Data, and Unstructured_Data
├── Services/                # Contains services like StructuredDataService
├── wwwroot/                 # Static files (e.g., images, CSS, JS)
├── Dockerfile               # Dockerfile for building and running the app
├── [docker-compose.yml](http://_vscodecontentref_/1)       # Docker Compose configuration (optional)
└── [readme.md](http://_vscodecontentref_/2)                # Project documentation
```

## Requirements

- .NET SDK 9.0
- Docker

## License

MIT

## Author

Kory Becker
https://primaryobjects.com
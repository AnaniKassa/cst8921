import logging
import requests

def main(event):
    logging.info("Event Grid trigger received")

    data = event.get_json()
    blob_url = data["url"]

    logging.info(f"Blob URL: {blob_url}")

    # Download blob content
    response = requests.get(blob_url)
    blob_content = response.text

    logging.info("Blob content retrieved successfully")
    logging.info(blob_content)

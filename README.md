# LastSeen Project

## Overview

The LastSeen project aims to display when a user was last seen online in the application. The project fetches user data from a specified API endpoint and presents it in a human-readable format.


## Features

### Core Features

1. **Show User Online Status**
    - Displays when each user was last online in a friendly format, e.g., "John was online just now."
  
2. **Localized Time Formats**
    - The time since the user was last online is displayed in a localized, human-readable format, such as "yesterday" or "long time ago."

3. **List All Users**
    - The application lists all users and their online status.

### Extension Points

1. **Localization Support**
    - Future development will include support for displaying the online status in multiple languages.


## Usage

1. **Clone the repository**
2. **Install required dependencies**
3. **Run the application**
4. **Visit the application via web browser**

### API Calls
- Fetch last seen data: `https://sef.podkolzin.consulting/api/users/lastSeen?offset=<NUMBER>`



## Requirements

- C#
- Rider IDE
- .NET Core 3.1 or above


## Contributing

1. **Fork the repository**
2. **Create a new branch for each feature or improvement**
3. **Commit your changes**
4. **Create a pull request**



## Acceptance Criteria

Criteria for each feature are outlined in detail under the Development Tasks section.



## API Documentation

For a comprehensive list of API endpoints, please refer to the [API Documentation](https://sef.podkolzin.consulting/swagger/index.html).


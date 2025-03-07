# TelemetryUI Project

A modern web interface for telemetry data visualization and monitoring built with Blazor and Tailwind CSS. This application provides real-time insights into system performance metrics, sensor data, and operational analytics through an intuitive dashboard interface.

![Project Preview](wwwroot/images/screenshot.png) <!-- Add your screenshot later -->

## Project Overview

TelemetryUI serves as a centralized monitoring solution for collecting, processing, and visualizing telemetry data from various sources. It's designed for engineers, system administrators, and operations teams who need real-time visibility into their systems' performance and health.

### Project Structure
```
telemetryUI/
├── src/
│   └── TelemetryUI/
│       └── TelemetryUI/
│           ├── Components/
│           │   ├── Dashboard/
│           │   └── Layout/
│           │       └── NavBar.razor
│           ├── Data/
│           │   └── TelemetryService.cs
│           ├── Models/
│           │   └── TelemetryData.cs
│           ├── Pages/
│           │   └── Index.razor
│           ├── wwwroot/
│           │   └── images/
│           └── Program.cs
└── Readme.md
```
### Key Use Cases
- System performance monitoring
- IoT device data visualization
- Application metrics tracking
- Real-time analytics dashboards
- Operational intelligence

## Features

- Real-time telemetry monitoring with live updates
- Interactive dashboard interface with customizable widgets
- Responsive navigation bar with notifications system
- Modern UI components using DaisyUI and Tailwind CSS
- Cross-platform compatibility (Windows, macOS, Linux)
- Data export capabilities (CSV, JSON)
- User authentication and role-based access control
- Configurable alert thresholds and notifications

## Technologies

- ASP.NET Core 6.0
- Blazor WebAssembly for client-side and server-side rendering
- Tailwind CSS + DaisyUI for responsive UI components
- HTML5/CSS3 for modern web standards
- C# 10 for backend logic and data processing
- Entity Framework Core for data persistence

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- Node.js (for CSS processing)
- IDE (VS Code or Visual Studio 2022+)
- Git for version control

## After Installation
```
# Navigate to project directory
cd /Users/cenkkiran/Desktop/PratiklerDotNet/telemetryUI/src/TelemetryUI/TelemetryUI

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```
## Installation

### Windows
```powershell
# Install Chocolatey (if not installed)
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

# Install dependencies
choco install dotnet-sdk -y 
choco install nodejs -y

# Clone repository
git clone https://github.com/yourusername/telemetryUI.git
cd telemetryUI

# Create images directory
New-Item -ItemType Directory -Path "src\TelemetryUI\TelemetryUI\wwwroot\images" -Force 

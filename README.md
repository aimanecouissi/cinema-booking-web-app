<img src="https://socialify.git.ci/aimanecouissi/cinema-booking-web-app/image?description=1&forks=1&issues=1&language=1&name=1&owner=1&pulls=1&stargazers=1&theme=Auto" alt="cinema-booking-web-app" />

# Cinema Booking Web Application 🎬

Welcome to the Cinema Booking Web Application repository! This web application was built as a personal project using ASP.NET Core and SQL Server. It allows for easy online purchase of movie tickets, enabling users to search for movies, showtimes, and make purchases. The backend system is accessible to cinema management for managing movies and showtimes.

## Features 🌟

- **Movie Search:** Users can search for movies and view detailed information.
- **Showtime Selection:** Users can choose showtimes and book tickets online.
- **Secure Payment:** Integrated payment system for secure transactions.
- **Admin Panel:** Cinema management can manage movies, showtimes, and bookings through the backend system.

## Technologies 💻

- **ASP.NET Core:** High-performance, cross-platform framework for building web applications.
- **SQL Server:** Relational database management system for storing application data.
- **HTML/CSS/JavaScript:** Frontend technologies for building the user interface.
- **Bootstrap:** Frontend framework for designing responsive and mobile-first websites.

## Demo 📹

Explore the application in action by watching the video demonstration available in [my portfolio](https://www.aimanecouissi.com/).

## Installation 🛠️

To run the application locally, follow these steps:

1. Clone the repository to your local machine.
2. Set up SQL Server and create a new database for the application.
3. Configure the database connection settings in the application code.
4. Ensure that the required NuGet packages are restored. This should be done automatically by Visual Studio or the .NET CLI based on the dependencies listed in the project's `.csproj` file.
5. Navigate to the `appsettings.json` file in the project directory.
6. Locate the `StripeSettings` section and replace the `PublishableKey` and `SecretKey` values with your own Stripe API keys. You can obtain these keys by signing up for a Stripe account and creating a new project.
7. Run migrations to create the necessary database schema and seed initial data.
8. Build and run the application using Visual Studio or the .NET CLI.


## Contributing 🤝

Contributions are welcome! If you'd like to contribute to the project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/my-new-feature`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add some feature'`).
5. Push to the branch (`git push origin feature/my-new-feature`).
6. Create a new Pull Request.

## License 📄

This project is licensed under the [MIT License](LICENSE).

## Contact 📧

For any inquiries or feedback, feel free to reach out to me at [contact@aimanecouissi.com](mailto:contact@aimanecouissi.com).

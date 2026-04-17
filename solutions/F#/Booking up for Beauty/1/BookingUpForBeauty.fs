module BookingUpForBeauty

// The following line is needed to use the DateTime type
open System

let schedule (appointmentDateDescription: string): DateTime = DateTime.Parse appointmentDateDescription

let hasPassed (appointmentDate: DateTime): bool =
    DateTime.Now > appointmentDate

let isAfternoonAppointment (appointmentDate: DateTime): bool =
    let hour = appointmentDate.Hour
    hour >= 12 && hour < 18

let description (appointmentDate: DateTime): string = $"You have an appointment on {appointmentDate.ToShortDateString()} {appointmentDate.ToLongTimeString()}."

let anniversaryDate(): DateTime = new DateTime(DateTime.Today.Year, 9, 15)

Async Inn Hotel
ERD Components
Hotel (Table)

Primary Key: HotelID
Name
City
State
Address
PhoneNumber
Room (Table)

Primary Key: RoomID
Foreign Key: RoomLayoutID (links to the RoomLayout table for the layout type)
Name (e.g., "Seahawks Snooze")
PetFriendly (boolean to indicate if the room is pet-friendly)
RoomLayout (Enum/Table)

Primary Key: LayoutID
LayoutName (e.g., "One bedroom", "Two bedrooms", "Studio")
Amenity (Table)

Primary Key: AmenityID
Name (e.g., "air conditioning", "coffee maker")
RoomAmenity (Pure Join Table)

Composite Key: RoomID + AmenityID
Foreign Key: RoomID (links to Room)
Foreign Key: AmenityID (links to Amenity)
HotelRoom (Joint Entity Table with Payload)

Composite Key: HotelID + RoomID
Foreign Key: HotelID (links to Hotel)
Foreign Key: RoomID (links to Room)
Price (price varies per location and per room number)
RoomNumber
Relationships
A Hotel can have many HotelRooms, so it's a one-to-many relationship between Hotel and HotelRoom.
A Room can have many Amenities and an Amenity can belong to many rooms, forming a many-to-many relationship. This is represented through the RoomAmenity table.
A Room has one RoomLayout and a RoomLayout can be associated with many rooms, forming a one-to-many relationship.
Explanations:
Hotel:

Represents each hotel location with its respective details. Each hotel is unique with its own ID.
Room:

Represents the different room types and names. The layout information is stored in a separate table, and the two are connected via a foreign key.
RoomLayout:

An enum or table that contains the different layout configurations a room can have.
Amenity:

Represents the different amenities that can be available in a room. These amenities can be shared across rooms.
RoomAmenity:

A join table that associates rooms with their respective amenities, since one room can have many amenities and vice versa.
HotelRoom:

Represents the specific rooms within a hotel. The price and room number are included here because they vary per hotel location.
This ERD structure ensures normalization of the database and maintains the relationships between different tables efficiently. It can be expanded or modified as per future requirements.

![image](Schema.png)
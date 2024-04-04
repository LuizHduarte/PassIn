-- CreateTable
CREATE TABLE "Events" (
    "Id" UUID NOT NULL PRIMARY KEY,
    "Title" TEXT NOT NULL,
    "Details" TEXT,
    "Slug" TEXT NOT NULL,
    "Maximum_Attendees" INTEGER
);

-- CreateTable
CREATE TABLE "Attendees" (
    "Id" UUID NOT NULL PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "Created_At" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Event_Id" UUID NOT NULL,
    CONSTRAINT "Attendees_Event_Id_fkey" FOREIGN KEY ("Event_Id") REFERENCES "Events" ("Id") ON DELETE CASCADE ON UPDATE CASCADE
);

-- CreateTable
CREATE TABLE "CheckIns" (
    "Id" UUID NOT NULL PRIMARY KEY,
    "Created_at" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Attendee_Id" UUID NOT NULL,
    CONSTRAINT "CheckIns_Attendee_Id_fkey" FOREIGN KEY ("Attendee_Id") REFERENCES "Attendees" ("Id") ON DELETE CASCADE ON UPDATE CASCADE
);

-- CreateIndex
CREATE UNIQUE INDEX "events_slug_key" ON "Events"("Slug");

-- CreateIndex
CREATE UNIQUE INDEX "attendees_event_id_email_key" ON "Attendees"("Event_Id", "Email");

-- CreateIndex
CREATE UNIQUE INDEX "check_ins_attendee_id_key" ON "CheckIns"("Attendee_Id");

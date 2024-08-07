-- Creazione tabelle

CREATE TABLE [dbo].[Camere] (
    [Numero]      INT             NOT NULL,
    [Descrizione] NVARCHAR (100)  NOT NULL,
    [Tipologia]   NVARCHAR (20)   NOT NULL,
    [TariffaBase] DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Numero] ASC)
);

CREATE TABLE [dbo].[Clienti] (
    [CodiceFiscale] NVARCHAR (16) NOT NULL,
    [Cognome]       NVARCHAR (50) NOT NULL,
    [Nome]          NVARCHAR (50) NOT NULL,
    [Citta]         NVARCHAR (50) NOT NULL,
    [Provincia]     NVARCHAR (50) NOT NULL,
    [Email]         NVARCHAR (50) NOT NULL,
    [Telefono]      NVARCHAR (15) NOT NULL,
    [Cellulare]     NVARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([CodiceFiscale] ASC)
);

CREATE TABLE [dbo].[Trattamenti] (
    [Id]                   INT             IDENTITY (1, 1) NOT NULL,
    [Descrizione]          NVARCHAR (50)   NOT NULL,
    [TariffaSupplementare] DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Prenotazioni] (
    [Id]                    INT             IDENTITY (1, 1) NOT NULL,
    [CodiceFiscaleCliente]  NVARCHAR (16)   NOT NULL,
    [NumeroCamera]          INT             NOT NULL,
    [DataPrenotazione]      DATETIME        NOT NULL,
    [NumeroProgressivoAnno] INT             NOT NULL,
    [Anno]                  INT             NOT NULL,
    [Dal]                   DATETIME        NOT NULL,
    [Al]                    DATETIME        NOT NULL,
    [CaparraConfirmatoria]  DECIMAL (18, 2) NOT NULL,
    [TariffaApplicata]      DECIMAL (18, 2) NOT NULL,
    [TrattamentoId]         INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CodiceFiscaleCliente]) REFERENCES [dbo].[Clienti] ([CodiceFiscale]),
    FOREIGN KEY ([NumeroCamera]) REFERENCES [dbo].[Camere] ([Numero]),
    FOREIGN KEY ([TrattamentoId]) REFERENCES [dbo].[Trattamenti] ([Id])
);

CREATE TABLE [dbo].[Servizi] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Descrizione] VARCHAR(100) NOT NULL,
    [Prezzo] DECIMAL(10, 2) NOT NULL
);

CREATE TABLE [dbo].[PrenotazioniServizi] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [IdPrenotazione]  INT             NOT NULL,
    [IdServizio]      INT             NOT NULL,
    [Data]            DATETIME        NOT NULL,
    [Quantita]        INT             NOT NULL,
    [Prezzo]          DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdPrenotazione]) REFERENCES [dbo].[Prenotazioni] ([Id]),
    FOREIGN KEY ([IdServizio]) REFERENCES [dbo].[Servizi] ([Id])
);

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL
);

-- Popolamento della tabella Camere
INSERT INTO [dbo].[Camere] (Numero, Descrizione, Tipologia, TariffaBase) VALUES
(201, 'Camera singola deluxe', 'Singola', 70.00),
(202, 'Camera doppia deluxe', 'Doppia', 100.00),
(203, 'Suite con vista mare', 'Suite', 200.00),
(204, 'Camera tripla', 'Tripla', 150.00),
(205, 'Camera familiare', 'Familiare', 180.00),
(206, 'Camera economica', 'Singola', 50.00),
(207, 'Camera standard', 'Doppia', 90.00);

-- Popolamento della tabella Clienti
INSERT INTO [dbo].[Clienti] (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) VALUES
('XYZABC80A01H501Z', 'Verdi', 'Anna', 'Bologna', 'BO', 'anna.verdi@example.com', '0512345678', '3289876543'),
('ABCDEF80A01H501Y', 'Rossi', 'Mario', 'Roma', 'RM', 'mario.rossi@example.com', '0612345678', '3281234567'),
('LMNOPQ80A01H501X', 'Bianchi', 'Lucia', 'Milano', 'MI', 'lucia.bianchi@example.com', '0287654321', '3287654321'),
('QRSTUV80A01H501W', 'Neri', 'Giovanni', 'Napoli', 'NA', 'giovanni.neri@example.com', '0812345678', '3282345678'),
('WXYZAB80A01H501V', 'Ferrari', 'Giulia', 'Firenze', 'FI', 'giulia.ferrari@example.com', '0552345678', '3281345678');

-- Popolamento della tabella Trattamenti
INSERT INTO [dbo].[Trattamenti] (Descrizione, TariffaSupplementare) VALUES
('Colazione inclusa', 10.00),
('Mezza pensione', 25.00),
('Pensione completa', 40.00),
('All inclusive', 60.00),
('Solo pernottamento', 0.00);

-- Popolamento della tabella Servizi
INSERT INTO [dbo].[Servizi] (Descrizione, Prezzo) VALUES
('Colazione in camera', 15.00),
('Bevande e cibo nel mini bar', 20.00),
('Internet', 5.00),
('Letto aggiuntivo', 25.00),
('Culla', 10.00),
('Servizio in camera', 30.00),
('Parcheggio', 10.00);

-- Popolamento della tabella Prenotazioni
INSERT INTO [dbo].[Prenotazioni] (CodiceFiscaleCliente, NumeroCamera, DataPrenotazione, NumeroProgressivoAnno, Anno, Dal, Al, CaparraConfirmatoria, TariffaApplicata, TrattamentoId) VALUES
('XYZABC80A01H501Z', 201, GETDATE(), 1, YEAR(GETDATE()), '2023-08-01', '2023-08-07', 70.00, 140.00, 1),
('ABCDEF80A01H501Y', 202, GETDATE(), 2, YEAR(GETDATE()), '2023-09-01', '2023-09-07', 100.00, 200.00, 2),
('LMNOPQ80A01H501X', 203, GETDATE(), 3, YEAR(GETDATE()), '2023-10-01', '2023-10-07', 200.00, 400.00, 3),
('QRSTUV80A01H501W', 204, GETDATE(), 4, YEAR(GETDATE()), '2023-11-01', '2023-11-07', 150.00, 300.00, 4),
('WXYZAB80A01H501V', 205, GETDATE(), 5, YEAR(GETDATE()), '2023-12-01', '2023-12-07', 180.00, 360.00, 5);

-- Popolamento della tabella PrenotazioniServizi
INSERT INTO [dbo].[PrenotazioniServizi] (IdPrenotazione, IdServizio, Data, Quantita, Prezzo) VALUES
(1, 1, '2023-08-02', 1, 15.00),
(1, 2, '2023-08-03', 1, 20.00),
(2, 3, '2023-09-02', 1, 5.00),
(3, 4, '2023-10-02', 1, 25.00),
(4, 5, '2023-11-02', 1, 10.00),
(5, 6, '2023-12-02', 1, 30.00);

-- Popolamento della tabella Users
INSERT INTO Users (Username, Password) VALUES
('user1', 'password1'),
('user2', 'password2'),
('user3', 'password3'),
('admin', 'adminpassword'),
('guest', 'guestpassword');

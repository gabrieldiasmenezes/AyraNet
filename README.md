# Ayra – Sistema de Prevenção de Desastres Naturais 🌪️

Projeto desenvolvido como parte da disciplina **Advanced Business Development with .NET**, com o objetivo de oferecer uma solução tecnológica inovadora e viável para auxiliar a população em situações de risco iminente, como deslizamentos e enchentes.

## 🚀 Descrição da Solução

Ayra é uma API RESTful que permite o monitoramento e gestão de alertas em áreas de risco com base em dados fornecidos por sensores. A API centraliza o gerenciamento de zonas de risco, alertas ativos e usuários cadastrados, possibilitando ações rápidas em momentos críticos.

## Desenvolvedor

Gabriel Dias Menezes-RM555019

## 🛠️ Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / Swashbuckle
- Razor Pages e TagHelpers
- AutoMapper
- FluentValidation

## 🧱 Estrutura do Projeto

O sistema foi dividido em 4 camadas de responsabilidade:

- `Ayra.Domain`: Contém os modelos de domínio e entidades do sistema.
- `Ayra.Application`: Serviços e regras de negócio.
- `Ayra.Infrastructure`: Responsável pela persistência de dados e configuração do banco.
- `Ayra.Api`: Camada de apresentação e execução da API, onde o sistema é executado.

## Vídeo demonstrativo

[Link do Vídeo de demostração](https://youtu.be/-bLjG4Py1Bw)

## 🚀 Instalação e Execução

1. Clonar o projeto
```bash
git clone https://github.com/gabrieldiasmenezes/AyraNet.git
cd AyraNet
```

2. Navegar até a pasta do projeto principal
```bash
cd Ayra.Api
```

3. Restaurar dependências (caso necessário)
```bash
dotnet restore
```

4. Aplicar as migrações do banco de dados
 Certifique-se de que a string de conexão esteja configurada corretamente no arquivo appsettings.json.
```bash
dotnet ef database update --project ../Ayra.Infrastructure
```

5. Rodar a aplicação
 Certifique-se de que a string de conexão esteja configurada corretamente no arquivo appsettings.json.
```bash
dotnet run
```

6. Teste com esses links

RazorPages e HelpTags
```bash
http://localhost:5119/Alerts/Index
```
Documentação Swagger
```bash
http://localhost:5119/swagger/index.html
```
## 🔗 Modelo Lógico do Banco de Dados
Veja o modelo lógico e banco de dados no projeto 

![image](https://github.com/user-attachments/assets/f5ea3a3e-c677-453d-912d-384e758a8611)


---

## 📡EndPoints por Entidades

### **🧍‍♂️ User**

| Método | Endpoint          | Descrição                 |
| ------ | ----------------- | ------------------------- |
| GET    | `/user`      | Retorna todos os usuários |
| GET    | `/user/{id}` | Retorna um usuário por ID |
| POST   | `/user`      | Cria um novo usuário      |
| PUT    | `/user/{id}` | Atualiza um usuário       |
| DELETE | `/user/{id}` | Deleta um usuário         |

### **☎️ Emergency Contact**

| Método | Endpoint                      | Descrição                               |
| ------ | ----------------------------- | --------------------------------------- |
| GET    | `/EmergencyContact`      | Retorna todos os contatos de emergência |
| GET    | `/EmergencyContact/{id}` | Retorna um contato por ID               |
| POST   | `/EmergencyContact`      | Cria um novo contato de emergência      |
| PUT    | `/EmergencyContact/{id}` | Atualiza um contato                     |
| DELETE | `/EmergencyContact/{id}` | Deleta um contato                       |

### **🧍‍♂️  Emergency User (ligação entre user e emergency contact)**

| Método | Endpoint                   | Descrição                                                   |
| ------ | -------------------------- | ----------------------------------------------------------- |
| GET    | `/emergencyUser`      | Retorna os vínculos entre usuários e contatos de emergência |
| GET    | `emergencyUser/{id}` | Retorna um vínculo por ID                                   |
| POST   | `/emergencyUser`      | Cria um novo vínculo                                        |
| PUT    | `/emergencyUser/{id}` | Atualiza um vínculo                                         |
| DELETE | `/emergencyUser/{id}` | Deleta um vínculo                                           |

### **🌍 Coordinate**

| Método | Endpoint                | Descrição                         |
| ------ | ----------------------- | --------------------------------- |
| GET    | `/coordinates`      | Retorna todas as coordenadas      |
| GET    | `/coordinates/{id}` | Retorna uma coordenada por ID     |
| POST   | `/coordinates`      | Cria uma nova coordenada          |
| PUT    | `/coordinates/{id}` | Atualiza uma coordenada existente |
| DELETE | `/coordinates/{id}` | Deleta uma coordenada             |

### **🗺️ Map Marker**

| Método | Endpoint               | Descrição                           |
| ------ | ---------------------- | ----------------------------------- |
| GET    | `/map-marker`      | Retorna todos os marcadores do mapa |
| GET    | `/map-marker/{id}` | Retorna um marcador específico      |
| POST   | `/map-marker`      | Cria um novo marcador no mapa       |
| PUT    | `/map-marker/{id}` | Atualiza um marcador existente      |
| DELETE | `/map-marker/{id}` | Remove um marcador                  |

### **🚨 Alert**

| Método | Endpoint           | Descrição                    |
| ------ | ------------------ | ---------------------------- |
| GET    | `/alert`      | Retorna todos os alertas     |
| GET    | `/alert/{id}` | Retorna um alerta específico |
| POST   | `/alert`      | Cria um novo alerta          |
| PUT    | `/alert/{id}` | Atualiza um alerta existente |
| DELETE | `/alert/{id}` | Remove um alerta             |

### **🛣️ Safe Route**

| Método | Endpoint               | Descrição                      |
| ------ | ---------------------- | ------------------------------ |
| GET    | `/safe-routes`      | Retorna todas as rotas seguras |
| GET    | `/safe-routes/{id}` | Retorna uma rota por ID        |
| POST   | `/safe-routes`      | Cria uma nova rota segura      |
| PUT    | `/safe-routes/{id}` | Atualiza uma rota existente    |
| DELETE | `/safe-routes/{id}` | Remove uma rota                |

### **🏠 Safe Location**

| Método | Endpoint                  | Descrição                          |
| ------ | ------------------------- | ---------------------------------- |
| GET    | `/safe-location`      | Retorna todos os locais seguros    |
| GET    | `/safe-location/{id}` | Retorna um local seguro específico |
| POST   | `/safe-location`      | Cria um novo local seguro          |
| PUT    | `/safe-location/{id}` | Atualiza um local existente        |
| DELETE | `/safe-location/{id}` | Remove um local seguro             |

### **💡 Safe Tip**

| Método | Endpoint             | Descrição                           |
| ------ | -------------------- | ----------------------------------- |
| GET    | `/safe-tip`      | Retorna todas as dicas de segurança |
| GET    | `/safe-tip/{id}` | Retorna uma dica específica         |
| POST   | `/safe-tip`      | Cria uma nova dica                  |
| PUT    | `/safe-tip/{id}` | Atualiza uma dica existente         |
| DELETE | `/safe-tip/{id}` | Remove uma dica                     |

---

### **📌 Testes da API – JSONs**

| Entidade              | Método | Endpoint                 | Exemplo de JSON (POST)                                                                                                                                                                                                                                                             |
| --------------------- | ------ | ------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Coordinate**        | POST   | `/coordinates`       | `{ "latitude": -27.5954, "longitude": -48.5480, "dateCoordinate": "2025-05-31T10:20:00Z" }`                                                                                                                                                                                        |                                                                                                                                                    |
| **User**              | POST   | `/user`             | `{ "name": "Gabriela Dias", "email": "gabriela.dias@example.com", "password": "SenhaForte123", "phone": "11999998888", "CoordinateId": 2 }`                                                                                                                                        |
| **Emergency Contact** | POST   | `/EmergencyContact` | `{ "name": "Defesa Civil", "phone": "199" }`                                                                                                                                                                                                                                       |
| **Emergency User**    | POST   | `/emergencyUser`    | `{ "emergencyContactId": 12, "userId": 9 }`                                                                                                                                                                                                                                        |
| **Map Marker**        | POST   | `/map-marker`        | `{ "title": "Zona de Deslizamento", "description": "Área com alto risco de deslizamento", "intensity": "high", "radius": 150.0, "coordinateId": 2 }`                                                                                                                               |
| **Alert**             | POST   | `/alert`            | `{ "title": "Chuva Intensa", "description": "Foram detectados indícios de fortes chuvas.", "intensity": "Alta", "alertDateTime": "2025-05-31T15:30:00", "location": "Serra do Norte, km 12", "radius": 1.5, "evacuationTime": "15 minutos", "coordinateId": 2, "mapMarkerId": 6 }` |
| **Safe Route**        | POST   | `/safe-routes`        | `{ "Route": "Siga pela Rua das Palmeiras até a Avenida Central. Evite áreas próximas ao rio.", "alertId": 3 }`                                                                                                                                                                     |
| **Safe Location**     | POST   | `/safe-location`     | `{ "Location": "Abrigo temporário na escola municipal João Paulo II com capacidade para 300 pessoas. Possui alimentação e assistência médica.", "alertId": 2 }`                                                                                                                    |
| **Safe Tip**          | POST   | `/safe-tip`          | `{ "description": "Em caso de deslizamento, não volte para buscar pertences. Siga imediatamente para um local seguro.", "alertId": 2 }`                                                                                                                                            |

Os métodos put apenas coloque o respectivo id que queira editar como primeiro item aser declarado
```json
{
  "id": 1,
  "_comentario": "Os outros dados do json aqui"
}
```


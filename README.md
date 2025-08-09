# Booking
<p>Previous therapy-clinic-api is only the name of the repository. The application is broader than that.</p>

## Flow
<img width="674" height="351" alt="flow" src="https://github.com/user-attachments/assets/dd700265-c2ff-4d7f-9cc7-ace5523139f9" />

## Business logic

<h4>Client entry his/her schedule</h4>

<img width="1230" height="513" alt="timeslots-joe" src="https://github.com/user-attachments/assets/a2d568e4-1a81-40da-9981-b24eca9232a3" />

<img width="583" height="231" alt="thereisalreadyatimelikethat" src="https://github.com/user-attachments/assets/f97addca-1b6f-45b5-abf6-da986bb016a1" />

<h4>Client's agenda</h4>

<img width="1238" height="398" alt="appointments-of-joe" src="https://github.com/user-attachments/assets/645c310d-983b-4b5a-8066-433abf0d5141" />

<h4>Client's client making an appointment</h4>
<p>All the available times are displayed.</p>
<img width="527" height="416" alt="make-appointment" src="https://github.com/user-attachments/assets/3f311798-729c-4a3a-b6b4-64b3acf69d72" />

<h4>Home</h4>
<img width="626" height="271" alt="image" src="https://github.com/user-attachments/assets/96768e34-25b5-471d-918c-1a08e3a5c262" />


## Docker
<h4>Execute the dockerized app</h4>
<h5>Apply migration on the root if there isn't one already.</h5>
<pre><code>
dotnet ef migrations add InitialCreate --project [data_layer] --startup-project [project_name]
</code></pre>
<pre><code>
docker-compose build --no-cache
</code></pre>
<h5>Update the database</h5>
<pre><code>
docker-compose run --rm [service_name] bash -c 'export PATH="$PATH:/root/.dotnet/tools" && dotnet ef database update --project [data_layer] --startup-project [project_name]
</code></pre>
<pre><code>
docker-compose up
</code></pre>
<h5>Check the ports and access jaeger UI</h5>
<pre><code>
docker ps
</code></pre>

## Observability
<ul>
    <ul>
        <li><strong>Tools</strong>:</li>
        <ul>
            <li><strong>OpenTelemetry</strong></li>
            <li><strong>Jaeger</strong></li>
        </ul>
    </ul>
</ul>

## Git Flow
<ul>
    <ul>
        <li><strong>Branches</strong>:</li>
        <ul>
            <li><strong>main</strong></li>
            <li><strong>release: </strong>copy of main;</li>
            <li><strong>hml: </strong> without the API project;</li>
        </ul>
    </ul>
</ul>

## Deployment
<p>Deployment is being made on AWS using the branch hml.</p>
<br/>

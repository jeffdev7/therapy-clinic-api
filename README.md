# Booking
<p>Previous therapy-clinic-api is only the name of the repository. The application is broader than that.</p>

## Flow
<img width="674" height="351" alt="flow" src="https://github.com/user-attachments/assets/dd700265-c2ff-4d7f-9cc7-ace5523139f9" />

## Business logic
#TO-DO
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
            <li><strong>release-non-prod: </strong> copy of hml;</li>
        </ul>
    </ul>
</ul>

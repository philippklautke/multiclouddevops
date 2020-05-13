import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { BlogPost } from './models/blogpost';
import { AppSettingsService } from './app-settings.service';

@Injectable({
  providedIn: 'root'
})
export class BlogPostService {



  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient, private appSettingsService: AppSettingsService) {

   }

   getBlogPosts():Observable<BlogPost[]>{
     return this.http.get<BlogPost[]>(this.appSettingsService.settings.apiUrl + 'api/BlogPosts/').pipe(retry(1),catchError(this.errorHandler));
   }
   getBlogPost(postId:number):Observable<BlogPost>{
     return this.http.get<BlogPost>(this.appSettingsService.settings.apiUrl + 'api/BlogPosts/' + postId).pipe(retry(1),catchError(this.errorHandler));
   }
   saveBlogPost(blogPost): Observable<BlogPost>{
     return this.http.post<BlogPost>(this.appSettingsService.settings.apiUrl + 'api/BlogPosts/', JSON.stringify(blogPost),this.httpOptions).pipe(retry(1),catchError(this.errorHandler));
   }
   updateBlogPost(postId:number,blogPost):Observable<BlogPost>{
     return this.http.put<BlogPost>(this.appSettingsService.settings.apiUrl + 'api/BlogPosts/' + postId, JSON.stringify(blogPost),this.httpOptions).pipe(retry(1),catchError(this.errorHandler));
   }
   deleteBlogPost(postId:number):Observable<BlogPost>{
     return this.http.delete<BlogPost>(this.appSettingsService.settings.apiUrl + 'api/BlogPosts/'+ postId).pipe(retry(1),catchError(this.errorHandler));
   }

   errorHandler(error){
     let errorMessage = '';
     if(error.error instanceof ErrorEvent){
       errorMessage = error.error.message;
     } else {
       errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
     }
     console.log(errorMessage);
     return throwError(errorMessage);
   }
}

import { Component, OnInit } from '@angular/core';
import { BlogPost } from '../models/blogpost';
import { Observable } from 'rxjs';
import { BlogPostService } from '../blog-post.service';
import { AppSettingsService } from '../app-settings.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-blog-posts',
  templateUrl: './blog-posts.component.html',
  styleUrls: ['./blog-posts.component.scss']
})
export class BlogPostsComponent implements OnInit {
  blogPosts: BlogPost[];
  constructor(private blogPostService: BlogPostService, private appSettingsService: AppSettingsService, private router: Router) {


   }

  ngOnInit() {
    this.loadBlogPosts();
  }

  loadBlogPosts(){
    this.appSettingsService.load().then(()=>{
    this.blogPostService.getBlogPosts().subscribe(data=>{
      this.blogPosts = data;
    });
  });
  }
  delete(postId){
    const ans = confirm('Do you want to delete blog post with id: '+postId);
    if(ans){
      this.blogPostService.deleteBlogPost(postId).subscribe((data) => {
        this.loadBlogPosts();
      });
    }
  }

}
